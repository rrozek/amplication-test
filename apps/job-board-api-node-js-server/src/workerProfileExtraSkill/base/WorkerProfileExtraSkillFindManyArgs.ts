/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { WorkerProfileExtraSkillWhereInput } from "./WorkerProfileExtraSkillWhereInput";
import { IsOptional, ValidateNested, IsInt } from "class-validator";
import { Type } from "class-transformer";
import { WorkerProfileExtraSkillOrderByInput } from "./WorkerProfileExtraSkillOrderByInput";

@ArgsType()
class WorkerProfileExtraSkillFindManyArgs {
  @ApiProperty({
    required: false,
    type: () => WorkerProfileExtraSkillWhereInput,
  })
  @IsOptional()
  @ValidateNested()
  @Field(() => WorkerProfileExtraSkillWhereInput, { nullable: true })
  @Type(() => WorkerProfileExtraSkillWhereInput)
  where?: WorkerProfileExtraSkillWhereInput;

  @ApiProperty({
    required: false,
    type: [WorkerProfileExtraSkillOrderByInput],
  })
  @IsOptional()
  @ValidateNested({ each: true })
  @Field(() => [WorkerProfileExtraSkillOrderByInput], { nullable: true })
  @Type(() => WorkerProfileExtraSkillOrderByInput)
  orderBy?: Array<WorkerProfileExtraSkillOrderByInput>;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  skip?: number;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  take?: number;
}

export { WorkerProfileExtraSkillFindManyArgs as WorkerProfileExtraSkillFindManyArgs };