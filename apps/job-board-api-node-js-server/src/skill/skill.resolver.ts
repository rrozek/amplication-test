import * as graphql from "@nestjs/graphql";
import { SkillResolverBase } from "./base/skill.resolver.base";
import { Skill } from "./base/Skill";
import { SkillService } from "./skill.service";

@graphql.Resolver(() => Skill)
export class SkillResolver extends SkillResolverBase {
  constructor(protected readonly service: SkillService) {
    super(service);
  }
}
