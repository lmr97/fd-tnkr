import json
import pandas as pd

all_tasks = pd.read_json("checklists/alltasks.json")
all_tasks.index += 1

segments = pd.read_json("checklists/segments.json")
segments.index += 1

filenames = ["amChecklist.json", "pmChecklist.json", "auditChecklist.json"]
files = [open(f"checklists/{f}") for f in filenames]
files_parsed = [json.load(f) for f in files]
[f.close() for f in files]

seg_map = []
for checklist in files_parsed:
    for section in checklist['sections']:
        seg_idx = segments[segments.startBy == section['startBy']].index[0]
        for task in section['listItems']:
            idx = all_tasks[all_tasks.Description == task['description']].index

            # find it manually
            if not len(idx):
                seg_map.append((int(seg_idx), "not found"))
            else:
                seg_map.append((int(seg_idx), int(idx[0])))

for p in seg_map:
    print(p, ",", sep="")