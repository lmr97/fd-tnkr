import { readFileSync, writeFileSync } from 'node:fs'
import validator from 'validator'
import express, { type Request, type Response } from 'express'
import { type RoomMap } from './types.ts'

const port = 8080
const ip   = "0.0.0.0"
const svr  = express()

const roomMapFileName = "valet_room_map.json"
const roomMapRawInit  = readFileSync(roomMapFileName, {encoding: "utf-8"})
let roomMap = JSON.parse(roomMapRawInit) as RoomMap

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
    
    const recvd = req.body
    try {
        roomMap = recvd as RoomMap
        writeFileSync(roomMapFileName, JSON.stringify(roomMap, null, 4))
        res.status(204).send("Valet/room map updated")
    }
    catch {
        const serialized = JSON.stringify(recvd, null, 4)
        res.status(400).send(`Invalid data format. Received: ${serialized}`)
        return
    }
}

svr.get("/", sendRoomMap)
svr.put("/", updateRoomMap)
svr.get("/ping", ping)

svr.use(express.json())

svr.listen(port, ip, () => console.log(`Server listening on ${ip}:${port}`))