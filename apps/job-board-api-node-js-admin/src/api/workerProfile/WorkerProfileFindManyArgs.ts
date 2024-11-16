import { WorkerProfileWhereInput } from "./WorkerProfileWhereInput";
import { WorkerProfileOrderByInput } from "./WorkerProfileOrderByInput";

export type WorkerProfileFindManyArgs = {
  where?: WorkerProfileWhereInput;
  orderBy?: Array<WorkerProfileOrderByInput>;
  skip?: number;
  take?: number;
};
