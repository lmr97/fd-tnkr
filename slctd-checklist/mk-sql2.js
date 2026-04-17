import fs from 'node:fs';

const shiftIdxMap = new Map([["AM", 1], ["PM", 2], ["Audit", 3]])
const rawJSON = shiftIdxMap.keys().map(k => {
    const fileName = `checklists/${k.toLowerCase()}Checklist.json`;
    return fs.readFileSync(fileName, "utf-8");
});
const parsed = rawJSON.map(JSON.parse)
var inserts = "INSERT INTO Segments (StartBy, DueBy, ChecklistId)\nVALUES\n";

for (const ckls of parsed) {
    for (const section of ckls.sections) {
        inserts += `('${section.startBy.replaceAll("'", "''")}', '${section.dueBy.replaceAll("'", "''")}','${shiftIdxMap.get(ckls.shift)}'),\n`
    }
}

inserts = inserts.slice(0, -2) + ";\n"


fs.writeFileSync("Segments_inserts.sql", inserts);
