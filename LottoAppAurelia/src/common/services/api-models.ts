interface IAuthorizeModel {
  id: number;
  userName: string;
  token: string;
  isAdmin: boolean;
}

interface IRegisterViewModel {
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  confirmPassword: string;
  age: number;
}

interface ILogInViewModel {
  userName: string;
  password: string;
}

interface ITicketPostModel {
  combination: string;
}

interface IResponceTicketViewModel {
  id: number;
  round: number;
  combination: string;
  roundCombination: string;
  status: number;
  prize: number;
  dateCreated: Date;
}

interface IRoundWinningCombination {
  round: number;
  winningCombination: string;
}

interface IRoundVIewModel {
  round: number;
  winningCombination: string;
  payIn: string;
  payOut: string;
  summary: string;
}

interface IWinningCombination {
  round: number;
  WinningCombination: string;
}





