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
import { ExtraSkillService } from "../extraSkill.service";
import { ExtraSkillCreateInput } from "./ExtraSkillCreateInput";
import { ExtraSkill } from "./ExtraSkill";
import { ExtraSkillFindManyArgs } from "./ExtraSkillFindManyArgs";
import { ExtraSkillWhereUniqueInput } from "./ExtraSkillWhereUniqueInput";
import { ExtraSkillUpdateInput } from "./ExtraSkillUpdateInput";

export class ExtraSkillControllerBase {
  constructor(protected readonly service: ExtraSkillService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: ExtraSkill })
  async createExtraSkill(
    @common.Body() data: ExtraSkillCreateInput
  ): Promise<ExtraSkill> {
    return await this.service.createExtraSkill({
      data: data,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [ExtraSkill] })
  @ApiNestedQuery(ExtraSkillFindManyArgs)
  async extraSkills(@common.Req() request: Request): Promise<ExtraSkill[]> {
    const args = plainToClass(ExtraSkillFindManyArgs, request.query);
    return this.service.extraSkills({
      ...args,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: ExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async extraSkill(
    @common.Param() params: ExtraSkillWhereUniqueInput
  ): Promise<ExtraSkill | null> {
    const result = await this.service.extraSkill({
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
  @swagger.ApiOkResponse({ type: ExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async updateExtraSkill(
    @common.Param() params: ExtraSkillWhereUniqueInput,
    @common.Body() data: ExtraSkillUpdateInput
  ): Promise<ExtraSkill | null> {
    try {
      return await this.service.updateExtraSkill({
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
  @swagger.ApiOkResponse({ type: ExtraSkill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteExtraSkill(
    @common.Param() params: ExtraSkillWhereUniqueInput
  ): Promise<ExtraSkill | null> {
    try {
      return await this.service.deleteExtraSkill({
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
