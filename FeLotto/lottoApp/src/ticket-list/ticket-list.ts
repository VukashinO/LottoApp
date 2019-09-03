import { ApiService } from '../services/api-service';
import {EventAggregator} from 'aurelia-event-aggregator';
import { inject } from 'aurelia-framework';
import { Events } from '../services/events';

@inject( ApiService, EventAggregator )
export class TicketList  {
    constructor( private service : ApiService, private eventAggregator : EventAggregator ) {}
    public tickets : IResponceTicketViewModel[] = [];

    public attached () {
        this.eventAggregator.subscribe(Events.ReloadTicketList, () => {
          this.getTickets();
        });

        this.getTickets();
    }

    private async getTickets() {
        this.tickets =  await this.service.getTicketsByUserId()
    }
}

