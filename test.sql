USE [Newsdb]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2ca20d5c-2488-4098-a2ea-9c927bfaeecb', N'Admin', N'ADMIN', N'10e4f9a6-8eff-4d7f-8031-c8f55fd07b19')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9a4cc83f-94bc-4e17-8279-8c215c0d6829', N'Customer', N'CUSTOMER', N'4c9dc833-c037-419a-a3e4-b16e5a9b1a54')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Name], [Surname], [Image], [IsVerify], [Profision], [About], [Adress], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', N'CustomUser', N'Ilkin', N'Aghayev', N'f5ea218b-0161-4d32-b9df-9d96ca4e3581-13102021025241-project-1.jpg', 1, N'Web Developer', NULL, N'Baku', N'ilkinga@code.edu.az', N'ILKINGA@CODE.EDU.AZ', N'ilkinga@code.edu.az', N'ILKINGA@CODE.EDU.AZ', 1, N'AQAAAAEAACcQAAAAEC1OkB9+pY57Rg9b+fbOlw+UzfYv1hSfIXKBEuUuO83m8Ab3hnSwc9eLsSc7BojCQA==', N'LNJOWENY2KFHC2CD63U5PLAQCZ235YAM', N'12669207-2447-4638-acee-be7180d27477', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Name], [Surname], [Image], [IsVerify], [Profision], [About], [Adress], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', N'CustomUser', N'Nihat', N'Aghayev', NULL, 0, NULL, NULL, NULL, N'ilkin200106@gmail.com', N'ILKIN200106@GMAIL.COM', N'ilkin200106@gmail.com', N'ILKIN200106@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEOHYmlC8FNtzdSO9SleE/ofxImSiSXZN8vRWA7hHziRdOaFh8CdZKxly2vt+lU6fiA==', N'GC5EKOVR4JMBDBKCSR6762WGIDDGGXAG', N'454798e2-d375-4f55-9b90-4a358010b578', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', N'2ca20d5c-2488-4098-a2ea-9c927bfaeecb')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', N'9a4cc83f-94bc-4e17-8279-8c215c0d6829')
GO
SET IDENTITY_INSERT [dbo].[NewsCategories] ON 

INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (1, N'Business')
INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (2, N'Entertainment')
INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (3, N'Travel')
INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (4, N'Fashion')
INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (5, N'Technology')
INSERT [dbo].[NewsCategories] ([Id], [Name]) VALUES (6, N'Life Style')
SET IDENTITY_INSERT [dbo].[NewsCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsSubCategories] ON 

INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (12, N'Default', 1)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (13, N'Default', 2)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (14, N'Default', 3)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (15, N'Default', 4)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (16, N'Default', 5)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (17, N'Game', 2)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (18, N'Celebrity', 2)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (19, N'Economy', 1)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (20, N'Hotels', 3)
INSERT [dbo].[NewsSubCategories] ([Id], [Name], [NewsCategoryId]) VALUES (21, N'Default', 6)
SET IDENTITY_INSERT [dbo].[NewsSubCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Title], [Image], [Content], [AddedDate], [CategoryId], [UserId], [NewsStatus], [NewsCategoryId]) VALUES (11, N'You wish lorem ipsum dolor sit amet consectetur', N'db09356a-075d-4f25-b22a-8e6baa5d3388-15102021051452-gal_4 (1).jpg', N'<p>Curabitur volutpat bibendum molestie. Vestibulum ornare gravida semper. Aliquam a dui suscipit, fringilla metus id, maximus leo. Vivamus sapien arcu, mollis eu pharetra vitae, condimentum in orci. Integer eu sodales dolor. Maecenas elementum arcu eu convallis rhoncus. Donec tortor sapien, euismod a faucibus eget, porttitor quis libero.</p>

<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sit amet est vel orci luctus sollicitudin. Duis eleifend vestibulum justo, varius semper lacus condimentum dictum. Donec pulvinar a magna ut malesuada. In posuere felis diam, vel sodales metus accumsan in. Duis viverra dui eu pharetra pellentesque. Donec a eros leo. Quisque sed ligula vitae lorem efficitur faucibus. Praesent sit amet imperdiet ante. Nulla id tellus auctor, dictum libero a, malesuada nisi. Nulla in porta nibh, id vestibulum ipsum. Praesent dapibus tempus erat quis aliquet. Donec ac purus id sapien condimentum feugiat.</p>

<p>Praesent vel mi bibendum, finibus leo ac, condimentum arcu. Pellentesque sem ex, tristique sit amet suscipit in, mattis imperdiet enim. Integer tempus justo nec velit fringilla, eget eleifend neque blandit. Sed tempor magna sed congue auctor. Mauris eu turpis eget tortor ultricies elementum. Phasellus vel placerat orci, a venenatis justo. Phasellus faucibus venenatis nisl vitae vestibulum. Praesent id nibh arcu. Vivamus sagittis accumsan felis, quis vulputate</p>
', CAST(N'2021-10-15T03:51:28.7743628' AS DateTime2), 16, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', 1, 1)
INSERT [dbo].[News] ([Id], [Title], [Image], [Content], [AddedDate], [CategoryId], [UserId], [NewsStatus], [NewsCategoryId]) VALUES (12, N'You ', N'13a13d17-1f85-45a9-8466-fa2f58bbff5a-15102021051911-404.jpg', N'<p>Curabitur volutpat bibendum molestie. Vestibulum ornare gravida semper. Aliquam a dui suscipit, fringilla metus id, maximus leo. Vivamus sapien arc</p>
', CAST(N'2021-10-15T05:19:11.2944526' AS DateTime2), 19, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', 1, NULL)
INSERT [dbo].[News] ([Id], [Title], [Image], [Content], [AddedDate], [CategoryId], [UserId], [NewsStatus], [NewsCategoryId]) VALUES (13, N'Test55556', N'5010ab12-01d7-4c12-9236-ffeb7aff4488-15102021054545-gal_2.jpg', N'<p>ko;ihkhjgbv&nbsp;</p>
', CAST(N'2021-10-15T05:45:45.4363611' AS DateTime2), 20, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', 1, NULL)
INSERT [dbo].[News] ([Id], [Title], [Image], [Content], [AddedDate], [CategoryId], [UserId], [NewsStatus], [NewsCategoryId]) VALUES (15, N'Test', N'898e3515-a96c-44e6-99b4-b7fd18df5237-15102021183911-gal_1.jpg', N'<p>cftghvbjknlm;,&#39;.dscs</p>
', CAST(N'2021-10-15T18:39:11.2939917' AS DateTime2), 12, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', 1, NULL)
INSERT [dbo].[News] ([Id], [Title], [Image], [Content], [AddedDate], [CategoryId], [UserId], [NewsStatus], [NewsCategoryId]) VALUES (16, N'aaaaaaaaaa', N'165594eb-4713-4de2-859a-75b60f5d7053-18102021013638-accordion-bg.jpg', N'<p>fvd</p>
', CAST(N'2021-10-18T01:36:38.7857012' AS DateTime2), 12, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', 1, NULL)
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[LikeAndDislikes] ON 

INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (510, 13, 1, N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', CAST(N'2021-10-16T23:41:50.3412584' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (689, 11, 2, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-17T00:30:10.6088792' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (696, 12, 2, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-17T00:30:57.9265950' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (697, 15, 1, N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', CAST(N'2021-10-17T00:31:45.6997594' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (698, 12, 2, N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', CAST(N'2021-10-17T00:31:48.4889474' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (699, 11, 2, N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', CAST(N'2021-10-17T00:31:50.4769008' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (701, 15, 1, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-17T01:01:16.1452287' AS DateTime2))
INSERT [dbo].[LikeAndDislikes] ([Id], [NewsId], [LikeAndDislikeStatus], [UserId], [AddedDate]) VALUES (702, 13, 2, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-17T18:16:40.0104321' AS DateTime2))
SET IDENTITY_INSERT [dbo].[LikeAndDislikes] OFF
GO
SET IDENTITY_INSERT [dbo].[SavedNews] ON 

INSERT [dbo].[SavedNews] ([Id], [NewsId], [UserId], [AddedDate]) VALUES (5, 11, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-15T04:59:35.0699797' AS DateTime2))
INSERT [dbo].[SavedNews] ([Id], [NewsId], [UserId], [AddedDate]) VALUES (12, 15, N'ac227d91-b89e-4fba-8d24-a9e69dda89ba', CAST(N'2021-10-16T03:13:49.7584830' AS DateTime2))
INSERT [dbo].[SavedNews] ([Id], [NewsId], [UserId], [AddedDate]) VALUES (13, 13, N'd10ed2c7-dfb8-4b2a-94d5-3e94b71df61e', CAST(N'2021-10-17T00:31:58.9365511' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SavedNews] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsTags] ON 

INSERT [dbo].[NewsTags] ([Id], [Name]) VALUES (1, N'Crafts')
INSERT [dbo].[NewsTags] ([Id], [Name]) VALUES (2, N'Streetstyle')
SET IDENTITY_INSERT [dbo].[NewsTags] OFF
GO
SET IDENTITY_INSERT [dbo].[TagToNews] ON 

INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (24, 11, 1)
INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (25, 11, 2)
INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (27, 13, 2)
INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (31, 15, 2)
INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (33, 12, 1)
INSERT [dbo].[TagToNews] ([Id], [NewsId], [TagId]) VALUES (34, 16, 1)
SET IDENTITY_INSERT [dbo].[TagToNews] OFF
GO
