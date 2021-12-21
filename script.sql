create sequence "Otp_Id_seq";

alter sequence "Otp_Id_seq" owner to postgres;

create table "Users"
(
    "Id"              bigserial
        constraint users_pk
            primary key,
    "ProfileImageUrl" varchar(256),
    "FullName"        varchar(64),
    "Email"           varchar(64),
    "Phone"           varchar(20),
    "Pass"            varchar(128),
    "UserType"        varchar(16),
    "IsVerified"      boolean default false
);

alter table "Users"
    owner to postgres;

create table "Projects"
(
    "Id"              bigserial
        constraint projects_pk
            primary key,
    "ProjectName"     varchar(128),
    "ProjectDetails"  varchar(1024),
    "ProjectImageUrl" varchar(256)
);

alter table "Projects"
    owner to postgres;

create table "Tasks"
(
    "Id"              bigserial
        constraint tasks_pk
            primary key,
    "TaskTitle"       varchar(128),
    "TaskDescription" varchar(1024),
    "CreatedAt"       timestamp,
    "Deadline"        timestamp,
    "TaskStatus"      varchar(16),
    "TaskType"        varchar(5),
    "ProjectId"       bigserial
        constraint tasks_projects_id_fk
            references "Projects"
            on delete cascade,
    "AssignedTo"      bigserial
        constraint tasks_users_id_fk
            references "Users"
            on delete cascade
);

alter table "Tasks"
    owner to postgres;

create table "TaskAttachments"
(
    "Id"      bigserial
        constraint taskattachments_pk
            primary key,
    "FileUrl" varchar(256),
    "TaskId"  bigserial
        constraint taskattachments_tasks_id_fk
            references "Tasks"
            on delete cascade
);

alter table "TaskAttachments"
    owner to postgres;

create table "FK_ProjectsUsers"
(
    "Id"              bigserial
        constraint fk_projectsusers_pk
            primary key,
    "ProjectId"       bigserial
        constraint fk_projectsusers_projects_id_fk
            references "Projects"
            on delete cascade,
    "UserId"          bigserial
        constraint fk_projectsusers_users_id_fk
            references "Users"
            on delete cascade,
    "IsOwner"         boolean,
    "IsProjectEditor" boolean,
    "IsTaskEditor"    boolean,
    "IsInvitor"       boolean
);

alter table "FK_ProjectsUsers"
    owner to postgres;

create table "Comments"
(
    "Id"          bigserial
        constraint comments_pk
            primary key,
    "TaskComment" varchar(1024),
    "TaskId"      bigserial
        constraint comments_tasks_id_fk
            references "Tasks"
            on delete cascade,
    "CommenterId" bigserial
        constraint comments_users_id_fk
            references "Users"
            on delete cascade
);

comment on table "Comments" is 'Table of Comments in Task';

alter table "Comments"
    owner to postgres;

create table "CommentAttachments"
(
    "Id"        bigserial
        constraint commentattachments_pk
            primary key,
    "FileUrl"   varchar(256),
    "CommentId" bigserial
        constraint commentattachments_comments_id_fk
            references "Comments"
            on delete cascade
);

alter table "CommentAttachments"
    owner to postgres;

create table "Auth"
(
    "Id"           bigserial
        constraint auth_pk
            primary key,
    "RefreshToken" varchar(256),
    "ExpiresAt"    date,
    "IpAddress"    varchar(20)
);

alter table "Auth"
    owner to postgres;

create table "Otps"
(
    "Id"     bigint default nextval('quickly."Otp_Id_seq"'::regclass) not null
        constraint otp_pk
            primary key,
    "Otp"    varchar(10),
    "UserId" bigserial
        constraint otps_users_id_fk
            references "Users"
            on delete cascade
);

alter table "Otps"
    owner to postgres;

alter sequence "Otp_Id_seq" owned by "Otps"."Id";


