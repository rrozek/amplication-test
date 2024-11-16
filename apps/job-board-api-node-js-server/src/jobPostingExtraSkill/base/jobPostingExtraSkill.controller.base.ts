/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { JobPostingExtraSkillService } from "../jobPostingExtraSkill.service";
import { JobPostingExtraSkillCreateInput } from "./JobPostingExtraSkillCreateInput";
import { JobPostingExtraSkill } from "./JobPostingExtraSkill";
import { JobPostingExtraSkillFindManyArgs } from "./JobPostingExtraSkillFindManyArgs";
import { JobPostingExtraSkillWhereUniqueInput } from "./JobPostingExtraSkillWhereUniqueInput";
import { JobPostingExtraSkillUpdateInput } from "./JobPostingExtraSkillUpdateInput";

export class JobPostingExtraSkillControllerBase {
  constructor(protected readonly service: JobPostingExtraSkillService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: JobPostingExtraSkill })
  async createJobPostingExtraSkill(
    @common.Body() data: JobPostingExtraSkillCreateInput
  ): Promise<JobPostingExtraSkill> {
    return await this.service.createJobPostingExtraSkill({
      data: data,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [JobPostingExtraSkill] })
  @ApiNestedQuery(JobPostingExtraSkillFindManyArgs)
  async jobPostingExtraSkills(
    @common.Req() request: Request
  ): Promise<JobPostingExtraSkill[]> {
    const args = plainToClass(JobPostingExtraSkillFindManyArgs, request.query);
    return this.service.jobPostingExtraSkills({
      ...args,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: JobPostingExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async jobPostingExtraSkill(
    @common.Param() params: JobPostingExtraSkillWhereUniqueInput
  ): Promise<JobPostingExtraSkill | null> {
    const result = await this.service.jobPostingExtraSkill({
      where: params,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: JobPostingExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async updateJobPostingExtraSkill(
    @common.Param() params: JobPostingExtraSkillWhereUniqueInput,
    @common.Body() data: JobPostingExtraSkillUpdateInput
  ): Promise<JobPostingExtraSkill | null> {
    try {
      return await this.service.updateJobPostingExtraSkill({
        where: params,
        data: data,
        select: {
          createdAt: true,
          id: true,
          updatedAt: true,
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: JobPostingExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteJobPostingExtraSkill(
    @common.Param() params: JobPostingExtraSkillWhereUniqueInput
  ): Promise<JobPostingExtraSkill | null> {
    try {
      return await this.service.deleteJobPostingExtraSkill({
        where: params,
        select: {
          createdAt: true,
          id: true,
          updatedAt: true,
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }
}
