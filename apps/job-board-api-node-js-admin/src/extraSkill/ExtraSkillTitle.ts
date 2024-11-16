import { ExtraSkill as TExtraSkill } from "../api/extraSkill/ExtraSkill";

export const EXTRASKILL_TITLE_FIELD = "id";

export const ExtraSkillTitle = (record: TExtraSkill): string => {
  return record.id?.toString() || String(record.id);
};
