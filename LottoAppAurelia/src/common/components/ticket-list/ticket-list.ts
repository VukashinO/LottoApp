import { ApiService } from '../../services/api-service';
import { EventAggregator } from 'aurelia-event-aggregator';
import { inject } from 'aurelia-framework';
import { Events } from '../../events/events';
import  moment  from 'moment';

@inject(ApiService, EventAggregator)
export class TicketList {

    public tickets: IResponceTicketViewModel[] = [];
    public ticketsColumns: ICustomColumn[] = [];
    constructor(private service: ApiService, private eventAggregator: EventAggregator) { }

    public attached() {
        this.eventAggregator.subscribe(Events.ReloadTicketList, () => {
            this.getTickets();
        });
        this.getTickets();
    }

    private async getTickets() {
        this.getTableColumns();
        this.tickets = await this.service.getTicketsByUserId();
        this.tickets.forEach(t => t.dateCreated =  moment(t.dateCreated).format('D MMM YYYY HH:mm:ss'));
    }

    private getTableColumns() {
        this.ticketsColumns = [
            {
                propertyName: 'round',
                propertyTitle: 'Round'
            }, {
                propertyName: 'combination',
                propertyTitle: 'Combinaton'
            }, {
                propertyName: 'roundCombination',
                propertyTitle: 'Round Combination'
            }, {
                propertyName: 'prize',
                propertyTitle: 'Prize'
            }, {
                propertyName: 'dateCreated',
                propertyTitle: 'Date Created'
            }
        ];
    }
}



