import { readFileSync, writeFileSync } from 'node:fs'
import { Ajv } from 'ajv'
import express, { type Request, type Response } from 'express'
import { type RoomMap } from './types.ts'

const port = 8080
const ip   = "0.0.0.0"
const svr  = express()

const roomMapFileName = "valet_room_map.json"
const schemaFileName  = "room_map.schema.json"
const schemaText      = readFileSync(schemaFileName, {encoding: "utf-8"})
const roomMapRawInit  = readFileSync(roomMapFileName, {encoding: "utf-8"})
const schema          = JSON.parse(schemaText)

let roomMap = JSON.parse(roomMapRawInit) as RoomMap

const schemaValidator = new Ajv()

function ping(req: Request, res: Response) {
    res.json({
        msg: "You found me!",
        reqFrom: req.ip, 
        time: new Date().toISOString()
    })
}

function sendRoomMap(_: Request, res: Response) {
    res.json(roomMap)
}

function updateRoomMap(req: Request, res: Response) {
    
    const recvd  = req.body
    const serial = JSON.stringify(recvd, null, 4)

    if (schemaValidator.validate(schema, recvd)) {
        writeFileSync(roomMapFileName, serial)
        res.status(204).send("Valet/room map updated")
    }
    else {
        res.status(400).send(`Invalid data. Received: ${serial}`)
        return
    }
}

// must come before routes
// only parses bodies with "application/json" content type
svr.use(express.json())  

svr.get("/", sendRoomMap)
svr.put("/", updateRoomMap)
svr.get("/ping", ping)

svr.listen(port, ip, () => console.log(`Server listening on ${ip}:${port}`))