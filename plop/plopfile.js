import path from "path";
import fs from "fs";
import inquirerDirectory from "inquirer-directory";

export default function (plop) {

  const config = {
    project: 'Nm',
    models: [
      {
        name: 'booking',
        fields: [
          { name: 'teaId', type: 'Guid', required: true },
          { name: 'flavourId', type: 'Guid', required: true },
          { name: 'toppingId', type: 'Guid', required: true },
          { name: 'sizeId', type: 'Guid', required: true },
          { name: 'price', type: 'Double' },
        ]
      }
    ]
  }



  const add = function (path, templateFile, data) {
    return { type: "add", path, templateFile , data};
  }

  const modify = function (path, templateFile, pattern, template, data) {
    // process.chdir(plop.getPlopfilePath());
    var changeFilePath = plop.getDestBasePath() + "/" + path;

    if (!fs.existsSync(changeFilePath)) {
      fs.writeFileSync(changeFilePath, fs.readFileSync(templateFile));
    }

    return { type: "modify", path, pattern, template, data};
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
  plop.setGenerator("model", {
    description: "Render model",
    prompts: [
      {
        type: "confirm", name: "name", message: "Have you done a commit? Continue?", 
      },
    ],
    actions: function (data) {

      var modelData  = { project: config.project, model: config.models[0]};



      var actions = [
        `Renerding Model`, 
        add("folder/{{properCase model.name}}.cs", "templates/domain/Booking.cs.hbs", modelData),
        // add("folder/{{dashCase name}}.txt", "templates/temp.txt"),
        // modify("folder/change-me.txt", "templates/change-me.txt", /(-- APPEND ITEMS HERE --)/gi, "$1\r\n{{name}}: {{age}}"),
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
