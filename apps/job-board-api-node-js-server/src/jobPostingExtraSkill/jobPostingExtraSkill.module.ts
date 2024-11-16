import { Module } from "@nestjs/common";
import { JobPostingExtraSkillModuleBase } from "./base/jobPostingExtraSkill.module.base";
import { JobPostingExtraSkillService } from "./jobPostingExtraSkill.service";
import { JobPostingExtraSkillController } from "./jobPostingExtraSkill.controller";
import { JobPostingExtraSkillResolver } from "./jobPostingExtraSkill.resolver";

@Module({
  imports: [JobPostingExtraSkillModuleBase],
  controllers: [JobPostingExtraSkillController],
  providers: [JobPostingExtraSkillService, JobPostingExtraSkillResolver],
  exports: [JobPostingExtraSkillService],
})
export class JobPostingExtraSkillModule {}
