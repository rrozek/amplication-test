import { Module } from "@nestjs/common";
import { JobPostingSkillModuleBase } from "./base/jobPostingSkill.module.base";
import { JobPostingSkillService } from "./jobPostingSkill.service";
import { JobPostingSkillController } from "./jobPostingSkill.controller";
import { JobPostingSkillResolver } from "./jobPostingSkill.resolver";

@Module({
  imports: [JobPostingSkillModuleBase],
  controllers: [JobPostingSkillController],
  providers: [JobPostingSkillService, JobPostingSkillResolver],
  exports: [JobPostingSkillService],
})
export class JobPostingSkillModule {}
