import path from "path";
import fs from "fs";
import inquirerDirectory from "inquirer-directory";

export default function (plop) {
  const add = function (path, templateFile) {
    return { type: "add", path, templateFile };
  }
  const modify = function (path, pattern, template) {
    return { type: "modify", path, pattern, template, };
  }

  const fileExists = function (path, template, answers) {
    process.chdir(plop.getPlopfilePath());
    var changeFilePath = plop.getDestBasePath() + path;

    if (fs.existsSync(changeFilePath)) {
      return plop.renderString("psst {{name}}, change-me.txt already exists", answers);
    } else {
      fs.writeFileSync(changeFilePath, fs.readFileSync(template));
      return plop.renderString("hey {{name}}, I copied change-me.txt for you", answers);
    }
  }

  plop.addHelper("dashAround", (text) => "---- " + text + " ----");
  plop.addHelper("wordJoin", function (words) {
    return words.join(", ").replace(/(:?.*),/, "$1, and");
  });
  plop.addHelper("absPath", function (p) {
    return path.resolve(plop.getPlopfilePath(), p);
  });
  plop.addPartial(
    "salutation",
    "{{ greeting }}, my name is {{ properCase name }} and I am {{ age }}."
  );
  plop.load("plop-pack-fancy-comments", {
    prefix: "",
    upperCaseHeaders: true,
    commentStart: "",
    commentEnd: "",
  });

  // setGenerator creates a generator that can be run with "plop generatorName"
  plop.setGenerator("test", {
    description: "this is a test",
    prompts: [
      {
        type: "input", name: "name", message: "What is your name?",
        validate: function (value) {
          if (/.+/.test(value)) { return true; }
          return "name is required";
        },
      },
      {
        type: "input", name: "age", message: "How old are you?",
        validate: function (value) {
          var digitsOnly = /\d+/;
          if (digitsOnly.test(value)) { return true; }
          return "Invalid age! Must be a number genius!";
        },
      },
      {
        type: "checkbox", name: "toppings", message: "What pizza toppings do you like?",
        choices: [
          { name: "Cheese", value: "cheese", checked: true },
          { name: "Pepperoni", value: "pepperoni" },
          { name: "Pineapple", value: "pineapple" },
          { name: "Mushroom", value: "mushroom" },
          { name: "Bacon", value: "bacon", checked: true },
        ],
      },
    ],
    actions: function (data) {
      var actions = [
        `this is a comment`,
        add("folder/{{dashCase name}}.txt", "templates/temp.txt"),
        (answers) => fileExists("/folder/change-me.txt", "templates/change-me.txt", answers),
        modify("folder/change-me.txt", /(-- APPEND ITEMS HERE --)/gi, "$1\r\n{{name}}: {{age}}"),
        // {
        //   type: "modify",
        //   path: "folder/change-me.txt",
        //   pattern: /(-- PREPEND ITEMS HERE --)/gi,
        //   templateFile: "templates/part.txt",
        // },
        // {
        //   type: "modify",
        //   path: "folder/change-me.txt",
        //   pattern: /## replace name here ##/gi,
        //   template: "replaced => {{dashCase name}}",
        // },
        // {
        //   type: "modify",
        //   path: "folder/change-me.txt",
        //   skip(data) {
        //     if (!data.toppings.includes("mushroom")) {
        //       // Skip this action
        //       return "Skipped replacing mushrooms";
        //     } else {
        //       // Continue with this action
        //       return;
        //     }
        //   },
        //   transform(fileContents, data) {
        //     return fileContents.replace(/mushrooms/g, "pepperoni");
        //   },
        // },
      ];
      return actions;
    },
  });


}
