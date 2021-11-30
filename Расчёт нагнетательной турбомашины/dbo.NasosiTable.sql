CREATE TABLE [dbo].[NasosiTable] (
    [Variant]    INT        IDENTITY (1, 1) NOT NULL,
    [t0 C]       INT        NOT NULL,
    [d вс]       INT        NOT NULL,
    [d н]        INT        NOT NULL,
    [l вс]       INT        NOT NULL,
    [l н]        INT        NOT NULL,
    [h вс]       FLOAT (53) NOT NULL,
    [h н]        FLOAT (53) NOT NULL,
    [p2]         INT        NOT NULL,
    [Лямбда]     FLOAT (53) NOT NULL,
    [Дзета кр]   INT        NOT NULL,
    [C]          INT        NOT NULL,
    [p0]         FLOAT (53) NOT NULL,
    [p н]        FLOAT (53) NULL,
    [v]          FLOAT (53) NULL,
    [p]          INT        NULL,
    [a]          INT        NULL,
    [Дзета откр] INT        NULL,
    PRIMARY KEY CLUSTERED ([Variant] ASC)
);

