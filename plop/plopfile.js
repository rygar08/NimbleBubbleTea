import path from "path";
import fs from "fs";
import inquirerDirectory from "inquirer-directory";
import { Helpers } from "./helpers.js";

export default function (plop) {

  var helpers = new Helpers(plop);

  const config = {
    project: 'Nm',
    models: [
      {
        name: 'booking', type: 'Guid',
        fields: [
          { name: 'teaId', type: 'Guid', required: true },
          { name: 'flavourId', type: 'Guid', required: true },
          { name: 'toppingId', type: 'Guid', required: true },
          { name: 'sizeId', type: 'Guid', required: true, options: 'cupSize' },
          { name: 'price', type: 'Double' },
        ]
      },
      {
        name: 'cupSize', type: 'string',
        fields: [
          { name: 'name', type: 'string' },
        ]
      },
      {
        name: 'flavour', type: 'Guid',
        fields: [
          { name: 'name', type: 'string' },
        ]
      },
      {
        name: 'topping', type: 'Guid',
        fields: [
          { name: 'name', type: 'string' },
        ]
      },
      {
        name: 'tea', type: 'Guid',
        fields: [
          { name: 'name', type: 'string' },
        ]
      }
    ]
  }


  plop.setGenerator("model", {
    description: "Render model",
    prompts: [{ type: "confirm", name: "name", message: "Have you done a commit? Continue?", },],
    actions: function (data) {
      var actions = [];
      config.models.forEach(m => {
        var modelData = { project: config.project, model: m };
        actions.push(helpers.add("folder/{{properCase model.name}}.cs", "templates/api/model.cs.hbs", modelData));
      });
      actions.push(helpers.add("folder/{{project}}ApplicationAutoMapperProfile.cs", "templates/api/applicationAutoMapperProfile.cs.hbs", config));
      actions.push(helpers.add("folder/{{project}}PermissionDefinitionProvider.cs", "templates/api/permissionDefinitionProvider.cs.hbs", config));
      actions.push(helpers.add("folder/{{project}}Permissions.cs", "templates/api/permissions.cs.hbs", config));

      // var actions = [
      //   `Renerding Model`,
      //   ,
      //   // add("folder/{{dashCase name}}.txt", "templates/temp.txt"),
      //   // modify("folder/change-me.txt", "templates/change-me.txt", /(-- APPEND ITEMS HERE --)/gi, "$1\r\n{{name}}: {{age}}"),
      //   // {
      //   //   type: "modify",
      //   //   path: "folder/change-me.txt",
      //   //   pattern: /(-- PREPEND ITEMS HERE --)/gi,
      //   //   templateFile: "templates/part.txt",
      //   // },
      //   // {
      //   //   type: "modify",
      //   //   path: "folder/change-me.txt",
      //   //   pattern: /## replace name here ##/gi,
      //   //   template: "replaced => {{dashCase name}}",
      //   // },
      //   // {
      //   //   type: "modify",
      //   //   path: "folder/change-me.txt",
      //   //   skip(data) {
      //   //     if (!data.toppings.includes("mushroom")) {
      //   //       // Skip this action
      //   //       return "Skipped replacing mushrooms";
      //   //     } else {
      //   //       // Continue with this action
      //   //       return;
      //   //     }
      //   //   },
      //   //   transform(fileContents, data) {
      //   //     return fileContents.replace(/mushrooms/g, "pepperoni");
      //   //   },
      //   // },
      // ];
      return actions;
    },
  });


}
