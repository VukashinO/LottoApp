interface Player {
    username : string,
    firstName : string, 
    lastName : string,
    balance : number,
    role : any
}

interface ITicketPostModel {
    combination : string
}

interface IResponceTicketViewModel {
    combination : string,
    userId : number,
    round: number,
    status : number,
    prize : number
}

interface ITicketValue {
    id: number,
    value: string
}

interface ICombinations {
    id: number,
    ticket: ITicketValue[]
}

interface IAuthorizeModel {
    id: number,
    email: string
    token: string,
    isAdmin: boolean
}

interface ILogInViewModel {
    userName: string,
    password: string
}