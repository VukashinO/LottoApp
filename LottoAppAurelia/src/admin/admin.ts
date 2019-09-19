import { inject } from 'aurelia-framework';
import { ApiService } from 'services/api-service';
import { Router } from 'aurelia-router';

@inject(ApiService, Router)
export class Admin {
    public roundResults: IRoundVIewModel[] = [];
    public roundColumns: ICustomColumn[] = [];
    constructor(private service: ApiService, private route: Router) { }
    public async attached() {
        await this.getRoundResults();
    }

    public async createRound() {
        await this.service.generateRound();
    }

    private async getRoundResults() {
        this.getTableColumns();
        this.roundResults = await this.service.getAllRounds();
    }

    public getTicketsByRoundId(round: number) {
        this.route.navigateToRoute('ticketsByRound', { roundId: round });
    }

    private getTableColumns() {
        this.roundColumns = [
            {
                propertyName: 'round',
                propertyTitle: 'Round'
            }, {
                propertyName: 'winningCombination',
                propertyTitle: 'WinningCombination'
            }, {
                propertyName: 'payIn',
                propertyTitle: 'Pay In'
            }, {
                propertyName: 'payOut',
                propertyTitle: 'Pay Out'
            }, {
                propertyName: 'summary',
                propertyTitle: 'Summary'
            }
        ];

    }






