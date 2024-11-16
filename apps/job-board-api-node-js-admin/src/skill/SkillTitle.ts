import { Skill as TSkill } from "../api/skill/Skill";

export const SKILL_TITLE_FIELD = "id";

export const SkillTitle = (record: TSkill): string => {
  return record.id?.toString() || String(record.id);
};
