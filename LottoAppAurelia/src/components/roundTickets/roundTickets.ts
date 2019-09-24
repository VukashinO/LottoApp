import { inject } from 'aurelia-framework';
import { ApiService } from 'services/api-service';

@inject(ApiService)
export class RoundTickets {

 public roundId: number;
 public ticketsByroundId: IResponceTicketViewModel[] = [];
 public ticketsByRoundColumns: ICustomColumn[] = [];
 public winningCombination: IWinningCombination;

 constructor(private service: ApiService) {}

    public async attached() {
        this.getTicketsByRoundColumns();
        await this.getTickets(this.roundId);
        await this.getWinningCombinationByRoundId(this.roundId);
    }

    activate(params) {
        this.roundId = +params.roundId;
    }

    private async getTickets(round: number) {
        this.ticketsByroundId =  await this.service.getTicketsByRoundId(round);
    }

    private async getWinningCombinationByRoundId(round: number) {
      this.winningCombination = await this.service.getWinningCombinationByRoundId(round);
    }

    private getTicketsByRoundColumns() {
       this.ticketsByRoundColumns = [
           {
            propertyName: 'combination',
            propertyTitle: 'Combination'
           },
           {
            propertyName: 'prize',
            propertyTitle: 'Prize'
           },
       ]
    }
}
