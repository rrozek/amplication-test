import { Module } from "@nestjs/common";
import { SkillModuleBase } from "./base/skill.module.base";
import { SkillService } from "./skill.service";
import { SkillController } from "./skill.controller";
import { SkillResolver } from "./skill.resolver";

@Module({
  imports: [SkillModuleBase],
  controllers: [SkillController],
  providers: [SkillService, SkillResolver],
  exports: [SkillService],
})
export class SkillModule {}
