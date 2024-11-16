import { Module } from "@nestjs/common";
import { ExtraSkillModuleBase } from "./base/extraSkill.module.base";
import { ExtraSkillService } from "./extraSkill.service";
import { ExtraSkillController } from "./extraSkill.controller";
import { ExtraSkillResolver } from "./extraSkill.resolver";

@Module({
  imports: [ExtraSkillModuleBase],
  controllers: [ExtraSkillController],
  providers: [ExtraSkillService, ExtraSkillResolver],
  exports: [ExtraSkillService],
})
export class ExtraSkillModule {}
