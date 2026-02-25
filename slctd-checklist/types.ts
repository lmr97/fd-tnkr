export enum Shift {
  AM = "AM", 
  PM = "PM", 
  NightAudit = "Night Audit" 
}

export type ListItem = {
  task: string,
  done: boolean
}

export type Section = {
  startBy: Date,
  dueBy: Date,
  listItems: Array<ListItem>
}

export type Checklist = {
  $schema: string,
  date: string,
  employee: string,
  shift: Shift,
  sections: Array<Section>
}