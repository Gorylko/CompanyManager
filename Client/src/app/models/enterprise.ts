import { Purchase } from './purchase';
import { Employee } from './employee';
import { WorkArea } from './workArea';

export class Enterprise{

    public name: string;

    public description: string;

    public employees?: Array<Employee>;

    public purchases?: Array<Purchase>;

    public workAreas?: Array<WorkArea>;
}