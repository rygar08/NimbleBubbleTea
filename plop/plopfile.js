import path from "path";
import fs from "fs";
import inquirerDirectory from "inquirer-directory";

export default function (plop) {
  // starting prompt can be customized to display what you want
  // plop.setWelcomeMessage('[CUSTOM]'.yellow + ' What can I do for you?');

  // helpers are passed through handlebars syntax and made
  // available for use in the generator templates

  // adds 4 dashes around some text (yes es6/es2015 is supported)
  plop.addHelper("dashAround", (text) => "---- " + text + " ----");

  // formats an array of options like you would write
  // it, if you were speaking (one, two, and three)
  plop.addHelper("wordJoin", function (words) {
    return words.join(", ").replace(/(:?.*),/, "$1, and");
  });

  plop.addHelper("absPath", function (p) {
    return path.resolve(plop.getPlopfilePath(), p);
  });

  // greet the user using a partial
  plop.addPartial(
    "salutation",
    "{{ greeting }}, my name is {{ properCase name }} and I am {{ age }}."
  );

  // load some additional helpers from a module installed using npm
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
        type: "input",
        name: "name",
        message: "What is your name?",
        validate: function (value) {
          if (/.+/.test(value)) {
            return true;
          }
          return "name is required";
        },
      },
      {
        type: "input",
        name: "age",
        message: "How old are you?",
        validate: function (value) {
          var digitsOnly = /\d+/;
          if (digitsOnly.test(value)) {
            return true;
          }
          return "Invalid age! Must be a number genius!";
        },
      },
      {
        type: "checkbox",
        name: "toppings",
        message: "What pizza toppings do you like?",
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
        {
          type: "add",
          path: "./jsOutput/{{dashCase name}}.txt",
          templateFile: "templates/temp.txt",
          abortOnFail: true,
        }, 
        {
          type: "modify",
          path: "folder/change-me.txt",
          pattern: /(-- APPEND ITEMS HERE --)/gi,
          template: "$1\r\n{{name}}: {{age}}",
        },
        {
          type: "modify",
          path: "folder/change-me.txt",
          pattern: /(-- PREPEND ITEMS HERE --)/gi,
          templateFile: "templates/part.txt",
        },
        {
          type: "modify",
          path: "folder/change-me.txt",
          pattern: /## replace name here ##/gi,
          template: "replaced => {{dashCase name}}",
        },
        {
          type: "modify",
          path: "folder/change-me.txt",
          skip(data) {
            if (!data.toppings.includes("mushroom")) {
              // Skip this action
              return "Skipped replacing mushrooms";
            } else {
              // Continue with this action
              return;
            }
          },
          transform(fileContents, data) {
            return fileContents.replace(/mushrooms/g, "pepperoni");
          },
        },
      ];
      return actions;
    },
  });

  // adding a custom inquirer prompt type
  // plop.addPrompt("directory", inquirerDirectory);

  // plop.setGenerator("custom-prompt", {
  //   description: "custom inquirer prompt example",
  //   prompts: [
  //     {
  //       type: "input",
  //       name: "fileName",
  //       message: "Pick a file name:",
  //       validate: function (value) {
  //         if (/.+/.test(value)) {
  //           return true;
  //         }
  //         return "file name is required";
  //       },
  //     },
  //     {
  //       type: "directory",
  //       name: "path",
  //       message: "where would you like to put this component?",
  //       basePath: plop.getPlopfilePath(),
  //     },
  //   ],
  //   actions: [
  //     function (data) {
  //       console.log(data);
  //       return "yay";
  //     },
  //     {
  //       type: "add",
  //       path: "{{absPath path}}/{{fileName}}.txt",
  //       template: "{{absPath path}}/{{fileName}} plopped!",
  //     },
  //   ],
  // });

  // test with dynamic actions, regarding responses to prompts
  plop.setGenerator("dynamic actions", {
    description: "another test using an actions function",
    prompts: [
      {
        type: "input",
        name: "name",
        message: "What is your name?",
        validate: function (value) {
          if (/.+/.test(value)) {
            return true;
          }
          return "name is required";
        },
      },
      {
        type: "confirm",
        name: "hasPotatoes",
        message: "Do you want potatoes with your burger?",
      },
    ],
    actions: function (data) {
      var actions = [
        {
          type: "add",
          path: "folder/{{dashCase name}}-burger.txt",
          templateFile: "templates/burger.txt",
          abortOnFail: true,
        },
      ];

      if (data.hasPotatoes) {
        actions = actions.concat([
          {
            type: "add",
            path: "folder/{{dashCase name}}-potatoes.txt",
            templateFile: "templates/potatoes.txt",
            abortOnFail: true,
          },
          {
            type: "modify",
            path: "folder/{{dashCase name}}-burger.txt",
            pattern: /(!\n)/gi,
            template: "$1Your potatoes: {{dashCase name}}-potatoes.txt",
          },
        ]);
      }

      return actions;
    },
  });
}