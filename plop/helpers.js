import path from "path";
import fs from "fs"; 

export class Helpers {

    constructor(plop) {
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
    }

    add(path, templateFile, data) {
        return { type: "add", path, templateFile, data, force: true };
    }

    modify(path, templateFile, pattern, template, data) {
        // process.chdir(plop.getPlopfilePath());
        var changeFilePath = plop.getDestBasePath() + "/" + path;

        if (!fs.existsSync(changeFilePath)) {
            fs.writeFileSync(changeFilePath, fs.readFileSync(templateFile));
        }

        return { type: "modify", path, pattern, template, data };
    } 

}
