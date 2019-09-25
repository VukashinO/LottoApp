import { ApiService } from "../../services/api-service";
import { inject } from "aurelia-framework";
import { Events } from "../../events/events";
import { EventAggregator } from "aurelia-event-aggregator";

@inject(ApiService,  EventAggregator)
export class Ticket {
  public numbers: ITicketPostModel[] = [];
  public errorDuplicate: boolean = false;
  constructor(
    private service: ApiService,
    private event: EventAggregator
  ) {}

  public attached() {
    this.getInputs();
    this.event.publish(Events.ReloadTicketList);
  }

  public getInputs() {
    this.numbers = [];
    for (let index = 0; index < 7; index++) {
      this.numbers.push({ combination: "" });
    }
  }

  public async onCreateTicket() {
    if (!this.checkIfSameNumber()) return;
    this.errorDuplicate = false;

    let postStringCombination = {
      combination: this.numbers.map(n => `${n.combination}`).join(";")
    };
    await this.service.createTicket(postStringCombination);
    this.event.publish(Events.ReloadTicketList);
    this.getInputs();
  }

  private checkIfSameNumber() {
    let uniqueValues: number[] = [];
    this.numbers.forEach(n => uniqueValues.push(+n.combination));
    let duplicate = uniqueValues.filter(
      (item, index) => uniqueValues.indexOf(item) === index
    );

    if (duplicate.length < 7) {
      this.errorDuplicate = true;
      return false;
    }

    return true;
  }
}

