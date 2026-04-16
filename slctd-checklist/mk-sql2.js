import fs from 'node:fs';

const shiftIdxMap = new Map([["AM", 1], ["PM", 2], ["Audit", 3]])
const rawJSON = shiftIdxMap.keys().map(k => {
    const fileName = `checklists/${k.toLowerCase()}Checklist.json`;
    return fs.readFileSync(fileName, "utf-8");
});
const parsed = rawJSON.map(JSON.parse)
const tasks = JSON.parse(allTasksRaw);
var inserts = "INSERT INTO ShiftTask (StartBy, DueBy, ChecklistId)\nVALUES\n";

for (const ckls of parsed) {
    
}
inserts += tasks.map(el => {
    return `('${el.ShortName.replaceAll("'", "''")}', '${el.Description.replaceAll("'", "''")}')`
}).join(",\n");

inserts += ";"

fs.writeFileSync("ShiftTask_inserts.sql", inserts);
