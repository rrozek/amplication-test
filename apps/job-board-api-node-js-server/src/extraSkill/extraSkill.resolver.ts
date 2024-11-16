import * as graphql from "@nestjs/graphql";
import { ExtraSkillResolverBase } from "./base/extraSkill.resolver.base";
import { ExtraSkill } from "./base/ExtraSkill";
import { ExtraSkillService } from "./extraSkill.service";

@graphql.Resolver(() => ExtraSkill)
export class ExtraSkillResolver extends ExtraSkillResolverBase {
  constructor(protected readonly service: ExtraSkillService) {
    super(service);
  }
}
