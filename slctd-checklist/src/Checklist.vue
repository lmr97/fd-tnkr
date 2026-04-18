<script setup lang="ts">
import { onBeforeMount, ref } from 'vue'
import { type Checklist, type Segment } from './types'
// import amClRaw from '../checklists/amChecklist.json?raw'
// import pmClRaw from '../checklists/pmChecklist.json?raw'
// import naClRaw from '../checklists/auditChecklist.json?raw'
const checklists = ref<Checklist[]>();
const clstate = ref<Checklist>();
const timeFmt = Intl.DateTimeFormat("en-us", {hour: "numeric", minute: "numeric"})

// the options available for form content
const allChecklists = ref<Map<string, Checklist>>();

async function fetchChecklists() {
    const response = await fetch(
        "https://localhost:7225/api/Checklist", 
        {
            method: "GET",
            headers: {
                "Access-Control-Allow-Headers": "Access-Control-Allow-Origin,Access-Control-Request-Method",
                "Access-Control-Allow-Origin": "*"
            }
        }
    )
    if (!response.ok) {
        throw new Error(`returned with status: ${response.status}: ${response.status}`)
    }

    checklists.value = await response.json()
    if (!checklists.value)
    {
        throw new Error("YOU FUCKING SUCK")
    }
    clstate.value = checklists.value[0];
    allChecklists.value = new Map([
        ["AM",    transformChecklist(checklists.value[0])], 
        ["PM",    transformChecklist(checklists.value[1])],
        ["Audit", transformChecklist(checklists.value[2])]
    ]);
}

// parse JSON, and transform array of strings into 
// array of state-holding objects (`ListItem`s)
function transformChecklist(stp: Checklist): Checklist {
    const now = new Date();
    const cldate = now.toISOString().split("T")[0]
    stp.date = cldate;
    stp.employee = "";
    stp.segments = stp.segments.map((s: Segment) => {
            return {
                startBy: new Date(cldate + "T" + s.startBy),
                dueBy:   new Date(cldate + "T" + s.dueBy),
                tasksToDo: s.tasksToDo.map((li) => {return {...li, done: false}})
            };
        }
    )
    return stp;
}

function submitForm() {
  console.log(
    clstate.value?.employee,
    clstate.value?.shift,
    clstate.value?.date,
    JSON.stringify(
      clstate?.value?.segments[0]?.tasksToDo[0]
    )
  )
}

onBeforeMount(fetchChecklists)

</script>

<template>
  <h1>{{ clstate?.shift }} Shift Checklist</h1>
  <form @submit.prevent="submitForm">
  
    <div class="in-wrap">
      <label for="employee">Employee</label>
      <input id="employee" v-model="clstate.employee" />
    </div>
  
    <div class="in-wrap">
      <label for="date">Date</label>
      <input id="date" v-model="clstate.date" />
    </div>

    <div class="in-wrap">
        <label for="shift">Shift</label>
        <div class="shift-wrap">
            <div v-for="[s, shiftChecklist] in allChecklists?.entries()">
                <!-- matching `id` and `for` is key to making the label clickable -->
                <!-- further, the atribute has to be prefaced with `:` 
                to bring the Vue variables into scope -->
                <input 
                    :id="s" 
                    type="radio" 
                    :value="s" 
                    v-model="clstate.shift" 
                    @click="clstate = shiftChecklist"
                />
                <label :for="s">{{ s }}</label>
            </div>
        </div>
    </div>
    
    <li v-for="segment in clstate?.segments" :key="segment.dueBy.getTime()">
      <div class="sect-wrap">
        <h2>{{ timeFmt.format(segment.startBy) }} &ndash; {{ timeFmt.format(segment.dueBy) }}</h2>
        <li class="task" v-for="item in segment.tasksToDo" :key="item.id">
            <div class="centered">
                <input type="checkbox" :id="item.id.toString()" v-model="item.done" />
            </div>
            <div class="task-text-wrap">
                <label :for="item.id.toString()">{{ item.description }}</label>
            </div>
        </li>
      </div>
    </li>
  
    <button id="submit-button" type="submit">Submit</button>

  </form>
</template>

<style scoped>
* {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}
.shift-wrap {
    display: flex;
    flex-direction: column;
}
#submit-button {
    font-size: large;
    padding: 8px;
    border-style: none;
    border-radius: 5px;
    color: white;
    background-color: purple;
    width: 100%;
    margin-bottom: 10px;
    transition-property: background-color;
    transition-duration: 0.2s;
    transition-timing-function: ease-in-out;
}
#submit-button:hover {
    background-color: blueviolet;
}
.in-wrap {
    font-weight: 500;
    margin-bottom: 20px;
    width: 300px;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}
h2 {
    margin: 8px;
}
li {
    list-style-type: none;
}
.task {
    display: flex;
    margin-top: 6px;
    margin-bottom: 6px;
}

.centered, .task-text-wrap {
    display: flex;
    align-items: center;
}
input:not([type="checkbox"]) {
    padding: 4px;
    border-style: solid;
    border-width: 1px;
    border-color: slategrey;
    border-radius: 5px;
}
input[type="checkbox"] {
    height: fit-content;
    transform: scale(1.6);
    border-radius: 20px;
    /* needed to help the box shadows conform to the box radius */
    background-color: #000; 
    margin: 15px;
    box-shadow: 0px 0px 7px #fff;
    transition-property: box-shadow;
    transition-duration: 0.1s;
}
input[type="checkbox"]:hover {
    box-shadow: 0px 0px 6px #5f4f5f;
}
.sect-wrap {
    font-weight: 500;
    background-color:#fff;
    margin-bottom: 20px;
    padding: 10px;
    border-style: solid;
    border-width: 1px;
    border-color: rgb(155, 164, 173);
    border-radius: 12px;
}
</style>
