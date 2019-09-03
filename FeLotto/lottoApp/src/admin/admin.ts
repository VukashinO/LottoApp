import { inject } from 'aurelia-framework';
import { Events } from 'services/events';
import {EventAggregator} from 'aurelia-event-aggregator';
import { ApiService } from 'services/api-service';

@inject(EventAggregator, ApiService)
export class Admin {
  message: string = 'Hello from Admin';
  public ticketsByround: IResponceTicketViewModel[] = []
  constructor(private event: EventAggregator, private service: ApiService) {}

  public attached () {
    this.event.subscribe(Events.TicketsByRound, () => {
      this.getTickets();
    });

    this.getTickets();
  }

  private async getTickets() {
      this.ticketsByround =  await this.service.getTicketsByRoundId();
  }
}
