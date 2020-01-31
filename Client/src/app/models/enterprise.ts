import { Purchase } from './purchase';
import { Employee } from './employee';
import { WorkArea } from './workArea';

export class Enterprise{

    public Name: string;

    public Description: string;

    public Employees?: Array<Employee>;

    public Purchases?: Array<Purchase>;

    public WorkAreas?: Array<WorkArea>;
}