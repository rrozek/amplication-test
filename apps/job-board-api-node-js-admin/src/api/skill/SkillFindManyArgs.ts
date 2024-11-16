import { SkillWhereInput } from "./SkillWhereInput";
import { SkillOrderByInput } from "./SkillOrderByInput";

export type SkillFindManyArgs = {
  where?: SkillWhereInput;
  orderBy?: Array<SkillOrderByInput>;
  skip?: number;
  take?: number;
};
