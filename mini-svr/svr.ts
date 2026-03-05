import express, { type Request, type Response } from 'express';

const port = 8080
const svr  = express()

function ping(req: Request, res: Response) {
    res.json({
        msg: "You found me!",
        reqFrom: req.ip, 
        time: new Date().toISOString()
    })
}

svr.get("/ping", ping)

svr.listen(port, () => console.log(`Server listening on port ${port}`))