Create database YANG
USE YANG 
GO
--用户信息表--
--用户名UserName
--用户UserId(主键)
--用户密码UserPwd
--头像HeadPortrait
--性别 Sex
--年龄 Age
--生日 Birthday
--星座 Constellation
--现居地 Address 
--婚姻状态 MaritalStatus
--血型 BloodType
--故乡 Hometown
--职业 Occupation
--公司名称CorporateName
--公司所在地CorporateAddress
--详细地址DetailedAddress
drop table UserInfo
Create Table UserInfo(
UserId int primary key identity(1,1) not null, --identity 设置字段自增长，步进值为1
UserName nvarchar(50)not null,
HeadPortrait nvarchar(50)not null,
Sex char(2)not null,
Age int not null,
Birthday date,
Constellation varchar(20),
[Address] nvarchar(50),
MaritalStatus char(2),
BloodType nvarchar(4),
Hometown nvarchar(50),
Occupation nvarchar(50),
CorporateName nvarchar(50),
CorporateAddress nvarchar(100),
DetailedAddress nvarchar(100)
)

--访问表(Visitor)
--主键id(主键)
--用户id(外键) UserId
--访问时间VisitorTime
--目标用户id UserToId
Create Table Visitor(
VisitorId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
VisitorTime datetime,
UserToId int
)

--分组表FriendGroup
--主键id(主键)
--分组名字GroupName
--所属用户id(外键)Userid
Create Table FriendGroup(
FriendGroupId int primary key identity(1,1),
GroupName nvarchar(50),
Userid int foreign key(UserId) references UserInfo(UserId),
)

--好友表(Friend)
--主键id(主键)
--分组id(外键) FriendGroupId
--好友用户id(外键) Userid
--好友备注Remarks
Create Table Friend(
FriendID int primary key identity(1,1),
FriendGroupId int foreign key(FriendGroupId) references FriendGroup(FriendGroupId),
Userid int foreign key(UserId) references UserInfo(UserId),
Remarks nvarchar(50)
)

--相册分组表(AlbumGroup)
--相册AlbumGroupid(主键)
--用户id(外键) UserId
--相册名称AGroupName
--创建时间CreateTime
Create Table AlbumGroup(
AlbumGroupid int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
AGroupName nvarchar(50),
CreateTime date,
)

--相册表(Album)
--照片id(主键)Albumid
--相册id(外键) AlbumGroupid
--照片名称AlbumName
--上传时间UploadTime
Create Table Album(
Albumid int primary key identity(1,1),
AlbumGroupid int foreign key(AlbumGroupid) references AlbumGroup(AlbumGroupid),
AlbumName nvarchar(50),
UploadTime date
)
--动态表(Dynamic)
--动态id(主键)DynamicId
--用户id(外键) UserId
--发布时间Releasetime
--发布内容Content
--动态图片Picture
--动态视频Video
Create Table Dynamic(
DynamicId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
Releasetime date,
Content nvarchar(200),
Picture nvarchar(100),
Video nvarchar(100),
)
--点赞表(Fabulous)
--点赞id(主键)
--动态id(外键) DynamicId
--点赞时间FabulousTime
--用户id  UserId
Create Table Fabulous(
FabulousId int primary key identity(1,1),
DynamicId int foreign key(DynamicId) references Dynamic(DynamicId),
FabulousTime date,
UserId int
)
--评论表(Comment)
--评论id(主键)CommentId
--动态id(外键) DynamicId
--评论内容CommentContent
--评论时间CommentTime
--评价用户id  UserToId
Create Table Comment(
CommentId int primary key identity(1,1),
DynamicId int foreign key(DynamicId) references Dynamic(DynamicId),
CommentContent nvarchar(200),
CommentTime date,
UserToId int
)
--回复表(Reply)
--回复id(主键)ReplyId
--回复类型ReplyType
--评论id(外键) CommentId
--回复评论id  CommentToId
--回复内容 ReplyContent
--回复时间 ReplyTime
--回复用户id UserToId
--目标用户id UserID
Create Table Reply(
ReplyId int primary key identity(1,1),
ReplyType char(2),
CommentId int foreign key(CommentId) references Comment(CommentId),
CommentToId int,
ReplyContent nvarchar(200),
ReplyTime date,
UserToId int,
UserID int,
)
--留言表(MessageBoard)
--留言id(主键)MessageId
--用户id(外键) UserId
--留言内容MessageContent
--留言时间MessageTime
--目标用户id  UserToId
Create Table MessageBoard(
MessageId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
MessageContent nvarchar(200),
MessageTime date,
UserToId int
)
--留言回复表MessageReply
--回复id(主键)MessageReplyId
--回复类型ReplyType
--留言id(外键) MessageId
--回复留言id MessageToId
--回复内容ReplyContent
--回复时间ReplyTime
--回复用户id UserToId
--目标用户id UserID
Create Table MessageReply(
MessageReplyId int primary key identity(1,1),
ReplyType char(2),
MessageId int foreign key(MessageId) references MessageBoard(MessageId),
MessageToId int,
ReplyContent nvarchar(200),
ReplyTime date,
UserToId int,
UserID int,
)






