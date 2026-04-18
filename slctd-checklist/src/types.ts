import { type Ref } from 'vue'

export enum Shift {
  AM = "AM", 
  PM = "PM", 
  Audit = "Audit" 
}

export type ShiftTask = {
  id: number,
  shortName: string,
  description: string,
  done?: boolean
}

export type SegmentRaw = {
  startBy: Date,
  dueBy: Date,
  listItems: Array<string>
}

export type Segment = {
  startBy: Date,
  dueBy: Date,
  tasksToDo: Array<ShiftTask>
}

export type Checklist = {
  $schema?: string,
  date?: string,
  employee?: string,
  shift: Shift,
  segments: Array<Segment>
}