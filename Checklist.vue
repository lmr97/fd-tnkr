<script setup lang="ts">
import { ref } from 'vue'
import { type Checklist, Shift } from './types'
const clraw = `{
    "$schema": "./schemata/checklistSubmission.schema.json",
    "date": "2026-02-20",
    "employee": "Martin",
    "shift": "AM",
    "sections": [
        {
            "startBy": "07:00:00-07:00",
            "dueBy": "09:00:00-07:00",
            "listItems": [
                {
                    "task": "Fill out occupancy information in Red Book and review any information needing to be passed along.",
                    "done": false
                },
                {
                    "task": "Count your drawer, and ensure it is at correct amount before beginning your shift. Ensure the drawer is balanced before the NA shift departs.",
                    "done": false
                },
                {
                    "task": "Login to GXP and review “All GXP Open Cases.”  Communicate with night auditor on any open or “In Progress” cases in GXP to ensure timely response and completion.",
                    "done": false
                },
                {
                    "task": "Check hotel's Gmail inbox (towneplacesuitesslc@gmail.com PW:slctd84101) for outstanding emails that require attention",
                    "done": false
                },
                {
                    "task": "Print the Contingency Reports: (F8-FOffice-Reports-Contingency Reports).",
                    "done": false
                },
                {
                    "task": "Straighten up the Lobby and wipe down the tables when it's necessary",
                    "done": false
                },
                {
                    "task": "Between 8:00AM-8:30AM - Call Red Hanger if guest laundry needs to be picked up.",
                    "done": false
                },
                {
                    "task": "Review your availability (F8-Rsrv-R-V).",
                    "done": false
                },
                {
                    "task": "Print Arrivals Report (F8-Rsrv-P-A-F10) in order to block rooms for the arriving Ambassador, Titanium, Platinum, Gold, and Silver guests.  Block remaining arrivals for today. (NOTE: MAKE SURE TO BLOCK GUESTS STAYING THROUGH THE WEEKEND ON THE EAST FACING SIDE TO AVOID MUSIC FROM SURROUNDING NIGHT CLUBS).",
                    "done": false
                },
                {
                    "task": "Add in company names for those with corporate rates.",
                    "done": false
                },
                {
                    "task": "Check for duplicate reservations (F8-Rsrv-P-D-Enter-F10) and keep them blocked in same room if it's available. Notify the Housekeeping Manager and/or Supervisor to clean as a “Stayover”.",
                    "done": false
                },
                {
                    "task": "Continuously monitor FOSSE home screen for any “Process Mobile” and “Process GuestRequest” alerts.  Prepare, complete and respond to all requests for Mobile Check-In and Mobile Requests in a timely manner.",
                    "done": false
                },
                {
                    "task": "Print PrePay Report (F8-FOffice-P-P) Ensure we have credit card payment for all guests.",
                    "done": false
                },
                {
                    "task": "Check credit cards for additional authorization. (F8-BOffice-C-C-Y-Enter-F4-Y-Enter) and notify guests as needed to update their account.",
                    "done": false
                },
                {
                    "task": "Print the credit card exception report (F8-BOffice-C-E-Y-Enter-Enter). Search for any declined credit cards and resolve.",
                    "done": false
                },
                {
                    "task": "Review any Out of Order rooms/maintenance requests that are pending and update in FOSSE.",
                    "done": false
                },
                {
                    "task": "Check the arrival report for non-member, then record their names on the Redbook table.",
                    "done": false
                }
            ]
        },
        {
            "startBy": "09:00:00-07:00",
            "dueBy": "11:00:00-07:00",
            "listItems": [
                {
                    "task": "Check for Internet Advance Deposit Reservations (F8-Rsrv-A-Q) (only if there are any reservations) *Important: This will take a minute to generate. Clear report Y/N? Hit N.    To post the advance deposit - Go into reservation of each guest - O – D – N. Charge the applicable credit card for the dollar amount provided. Hit F10. The amount of the advance deposit will appear in the Account Detail box at top right on Adv Deposit. Ensure there is a ‘D7’ in the special request field for incidental folio.  Clear from report Y/N? Hit yes if amount has been posted and appears in the account detail box.",
                    "done": false
                },
                {
                    "task": "Print the Contingency Reports: (F8-FOffice-Reports-Contingency Reports).",
                    "done": false
                },
                {
                    "task": "Update MARSHA Interface Status. (F8-Rsrv-M-D). Make sure that MARSHA interface is running properly. You can tell by the cursor moving automatically through the sections. If it seems to be frozen or not responding properly, call PMS Support at 240-632-6000 Option 1-2-2 and ask for help. When done checking, hit “E” to get out of this screen.",
                    "done": false
                },
                {
                    "task": "Sign in to the DLZ and complete Daily Learning Questions on the home screen",
                    "done": false
                },
                {
                    "task": "Sign in to the DLZ: click on TRAINING and work on completing recommended and/or required training (Best practice: spend 15-30 minutes per shift, or as time allows)",
                    "done": false
                },
                {
                    "task": "Read and respond to any training emails from AGM",
                    "done": false
                },
                {
                    "task": "Restock and arrange the back office storage with all guest amenities.",
                    "done": false
                },
                {
                    "task": "Organize the In-A-Pinch storage area.",
                    "done": false
                }
            ]
        },
        {
            "startBy": "11:00:00-07:00",
            "dueBy": "14:30:00-07:00",
            "listItems": [
                {
                    "task": "Print departure list and verify with housekeeping that all scheduled departures have vacated the room and then check the guest out in FOSSE",
                    "done": false
                },
                {
                    "task": "Check Credit Card Authorization Binder for today's date and update reservations with correct method of payment.",
                    "done": false
                },
                {
                    "task": "Refresh Coffee & Water Station.",
                    "done": false
                },
                {
                    "task": "Clean and Sanitized the Key Cards",
                    "done": false
                },
                {
                    "task": "Complete Bucket Check (F8-FOffice-F-B). Check credit card number, address, company name, departure date, and rate are all correct.",
                    "done": false
                },
                {
                    "task": "Stock In a Pinch Market and take out any expired items.  Give all expired items to AGM.",
                    "done": false
                },
                {
                    "task": "Print Discrepancies (F8-RoomMgt-H-P-D-5-Enter-Enter) and resolve with Housekeeping.",
                    "done": false
                },
                {
                    "task": "Verify any Unexpected Stayovers (F8-RoomMgt-H-P-U).",
                    "done": false
                },
                {
                    "task": "Clean and straighten up Front Desk area. Wipe down monitor screens and counters.",
                    "done": false
                },
                {
                    "task": "Log all incoming packages and notify in-house guests.",
                    "done": false
                },
                {
                    "task": "PARKING PASSES: Collect parking passes from garage (Send maintenance with the key if you can't leave the desk) and reconcile all passes due back",
                    "done": false
                }
            ]
        },
        {
            "startBy": "14:30:00-07:00",
            "dueBy": "15:00:00-07:00",
            "listItems": [
                {
                    "task": "Count your cash to determine if a drop is needed. Wait for the PM shift to count the drawer before departing your shift.",
                    "done": false
                },
                {
                    "task": "Run Shift Closing report BUT DO NOT UPDATE IT YET. (F8-FOffice-C-S, “Option”=P F10). Review amount to drop and review to ensure proper charge codes, and fix if needed so that drop reflects Closing Report.",
                    "done": false
                },
                {
                    "task": "Run Shift Closing reports * Now close out Shift 2 (F8-FOffice-C-S “Option”=U F10, follow prompts to update to next shift).",
                    "done": false
                },
                {
                    "task": "Look at GXP and review “All GXP Open Cases.”  Ensure all cases are either closed or passed on to next shift.",
                    "done": false
                }
            ]
        }
    ]
}`
const stp = JSON.parse(clraw) as Checklist
const cldate = stp.date
stp.sections.forEach((s) => {
    s.startBy = new Date(cldate + "T" + s.startBy)
    s.dueBy   = new Date(cldate + "T" + s.dueBy)
  }
)
const clstate = ref<Checklist>(stp)
const timeFmt = Intl.DateTimeFormat("en-us", {hour: "numeric", minute: "numeric"})

function submitForm() {
  console.log(
    clstate.value.employee,
    clstate.value.date,
    JSON.stringify(
      clstate.value.sections[0].listItems[0]
    )
  )
}

</script>

<template>
  <h1>{{ clstate.shift }} Shift Checklist</h1>
  <form @submit.prevent="submitForm">
  
    <div class="in-wrap">
      <label for="employee">Employee:</label>
      <input id="employee" v-model="clstate.employee" />
    </div>
  
    <div class="in-wrap">
      <label for="date">Date:</label>
      <input id="date" v-model="clstate.date" />
    </div>

    <div class="in-wrap">
        <label for="shift">Shift:</label>
        <div v-for="s in Shift">
            <!-- matching `id` and `for` is key to making the label clickable -->
            <!-- further, the atribute has to be prefaced with `:` to bring the Vue variables into scope -->
            <input :id="s" type="radio" :value="s" v-model="clstate.shift" />
            <label :for="s">{{ s }}</label>
        </div>
    </div>
    
    <li v-for="section in clstate.sections" :key="section.dueBy.getTime()">
      <div class="sect-wrap">
        <h2>{{ timeFmt.format(section.startBy) }} &ndash; {{ timeFmt.format(section.dueBy) }}</h2>
        <li class="task" v-for="item in section.listItems" :key="item.task">
          <input type="checkbox" :id="item.task" v-model="item.done" />
          <div class="task-text-wrap">
            <label :for="item.task">{{ item.task }}</label>
          </div>
        </li>
      </div>
    </li>
  
    <button id="submit-button" type="submit">Submit</button>

  </form>
</template>

<style scoped>
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
    transition-duration: 0.3s;
    transition-timing-function: ease-in-out;
}
#submit-button:hover {
    background-color: blueviolet;
}
.in-wrap {
    margin-bottom: 20px;
    width: 80%;
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

.task-text-wrap {
    display: flex;
    align-items: center;
}
input[type="checkbox"] {
    margin: 10px;
}
.sect-wrap {
    margin-bottom: 20px;
    padding: 5px;
    border-style: solid;
    border-width: 1px;
    border-color: slategrey;
    border-radius: 5px;
}
</style>