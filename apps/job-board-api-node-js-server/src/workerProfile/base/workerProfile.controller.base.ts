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
import { WorkerProfileService } from "../workerProfile.service";
import { WorkerProfileCreateInput } from "./WorkerProfileCreateInput";
import { WorkerProfile } from "./WorkerProfile";
import { WorkerProfileFindManyArgs } from "./WorkerProfileFindManyArgs";
import { WorkerProfileWhereUniqueInput } from "./WorkerProfileWhereUniqueInput";
import { WorkerProfileUpdateInput } from "./WorkerProfileUpdateInput";

export class WorkerProfileControllerBase {
  constructor(protected readonly service: WorkerProfileService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: WorkerProfile })
  async createWorkerProfile(
    @common.Body() data: WorkerProfileCreateInput
  ): Promise<WorkerProfile> {
    return await this.service.createWorkerProfile({
      data: data,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [WorkerProfile] })
  @ApiNestedQuery(WorkerProfileFindManyArgs)
  async workerProfiles(
    @common.Req() request: Request
  ): Promise<WorkerProfile[]> {
    const args = plainToClass(WorkerProfileFindManyArgs, request.query);
    return this.service.workerProfiles({
      ...args,
      select: {
        createdAt: true,
        id: true,
        updatedAt: true,
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: WorkerProfile })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async workerProfile(
    @common.Param() params: WorkerProfileWhereUniqueInput
  ): Promise<WorkerProfile | null> {
    const result = await this.service.workerProfile({
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
  @swagger.ApiOkResponse({ type: WorkerProfile })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async updateWorkerProfile(
    @common.Param() params: WorkerProfileWhereUniqueInput,
    @common.Body() data: WorkerProfileUpdateInput
  ): Promise<WorkerProfile | null> {
    try {
      return await this.service.updateWorkerProfile({
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
  @swagger.ApiOkResponse({ type: WorkerProfile })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteWorkerProfile(
    @common.Param() params: WorkerProfileWhereUniqueInput
  ): Promise<WorkerProfile | null> {
    try {
      return await this.service.deleteWorkerProfile({
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