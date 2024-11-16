import { ExtraSkillWhereInput } from "./ExtraSkillWhereInput";
import { ExtraSkillOrderByInput } from "./ExtraSkillOrderByInput";

export type ExtraSkillFindManyArgs = {
  where?: ExtraSkillWhereInput;
  orderBy?: Array<ExtraSkillOrderByInput>;
  skip?: number;
  take?: number;
};
