import { WorkerProfileSkillWhereInput } from "./WorkerProfileSkillWhereInput";
import { WorkerProfileSkillOrderByInput } from "./WorkerProfileSkillOrderByInput";

export type WorkerProfileSkillFindManyArgs = {
  where?: WorkerProfileSkillWhereInput;
  orderBy?: Array<WorkerProfileSkillOrderByInput>;
  skip?: number;
  take?: number;
};
