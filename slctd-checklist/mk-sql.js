import fs from 'node:fs';

const allTasksRaw = fs.readFileSync("checklists/alltasks.json", "utf-8");
const tasks = JSON.parse(allTasksRaw);
var inserts = "INSERT INTO ShiftTask (ShortName, Description)\nVALUES\n";

inserts += tasks.map(el => {
    return `('${el.ShortName.replaceAll("'", "''")}', '${el.Description.replaceAll("'", "''")}')`
}).join(",\n");

inserts += ";"

fs.writeFileSync("ShiftTask_inserts.sql", inserts);
