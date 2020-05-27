Create database YANG
USE YANG 
GO
--�û���Ϣ��--
--�û���UserName
--�û�UserId(����)
--�û�����UserPwd
--ͷ��HeadPortrait
--�Ա� Sex
--���� Age
--���� Birthday
--���� Constellation
--�־ӵ� Address 
--����״̬ MaritalStatus
--Ѫ�� BloodType
--���� Hometown
--ְҵ Occupation
--��˾����CorporateName
--��˾���ڵ�CorporateAddress
--��ϸ��ַDetailedAddress
drop table UserInfo
Create Table UserInfo(
UserId int primary key identity(1,1) not null, --identity �����ֶ�������������ֵΪ1
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

--���ʱ�(Visitor)
--����id(����)
--�û�id(���) UserId
--����ʱ��VisitorTime
--Ŀ���û�id UserToId
Create Table Visitor(
VisitorId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
VisitorTime datetime,
UserToId int
)

--�����FriendGroup
--����id(����)
--��������GroupName
--�����û�id(���)Userid
Create Table FriendGroup(
FriendGroupId int primary key identity(1,1),
GroupName nvarchar(50),
Userid int foreign key(UserId) references UserInfo(UserId),
)

--���ѱ�(Friend)
--����id(����)
--����id(���) FriendGroupId
--�����û�id(���) Userid
--���ѱ�עRemarks
Create Table Friend(
FriendID int primary key identity(1,1),
FriendGroupId int foreign key(FriendGroupId) references FriendGroup(FriendGroupId),
Userid int foreign key(UserId) references UserInfo(UserId),
Remarks nvarchar(50)
)

--�������(AlbumGroup)
--���AlbumGroupid(����)
--�û�id(���) UserId
--�������AGroupName
--����ʱ��CreateTime
Create Table AlbumGroup(
AlbumGroupid int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
AGroupName nvarchar(50),
CreateTime date,
)

--����(Album)
--��Ƭid(����)Albumid
--���id(���) AlbumGroupid
--��Ƭ����AlbumName
--�ϴ�ʱ��UploadTime
Create Table Album(
Albumid int primary key identity(1,1),
AlbumGroupid int foreign key(AlbumGroupid) references AlbumGroup(AlbumGroupid),
AlbumName nvarchar(50),
UploadTime date
)
--��̬��(Dynamic)
--��̬id(����)DynamicId
--�û�id(���) UserId
--����ʱ��Releasetime
--��������Content
--��̬ͼƬPicture
--��̬��ƵVideo
Create Table Dynamic(
DynamicId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
Releasetime date,
Content nvarchar(200),
Picture nvarchar(100),
Video nvarchar(100),
)
--���ޱ�(Fabulous)
--����id(����)
--��̬id(���) DynamicId
--����ʱ��FabulousTime
--�û�id  UserId
Create Table Fabulous(
FabulousId int primary key identity(1,1),
DynamicId int foreign key(DynamicId) references Dynamic(DynamicId),
FabulousTime date,
UserId int
)
--���۱�(Comment)
--����id(����)CommentId
--��̬id(���) DynamicId
--��������CommentContent
--����ʱ��CommentTime
--�����û�id  UserToId
Create Table Comment(
CommentId int primary key identity(1,1),
DynamicId int foreign key(DynamicId) references Dynamic(DynamicId),
CommentContent nvarchar(200),
CommentTime date,
UserToId int
)
--�ظ���(Reply)
--�ظ�id(����)ReplyId
--�ظ�����ReplyType
--����id(���) CommentId
--�ظ�����id  CommentToId
--�ظ����� ReplyContent
--�ظ�ʱ�� ReplyTime
--�ظ��û�id UserToId
--Ŀ���û�id UserID
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
--���Ա�(MessageBoard)
--����id(����)MessageId
--�û�id(���) UserId
--��������MessageContent
--����ʱ��MessageTime
--Ŀ���û�id  UserToId
Create Table MessageBoard(
MessageId int primary key identity(1,1),
UserId int foreign key(UserId) references UserInfo(UserId),
MessageContent nvarchar(200),
MessageTime date,
UserToId int
)
--���Իظ���MessageReply
--�ظ�id(����)MessageReplyId
--�ظ�����ReplyType
--����id(���) MessageId
--�ظ�����id MessageToId
--�ظ�����ReplyContent
--�ظ�ʱ��ReplyTime
--�ظ��û�id UserToId
--Ŀ���û�id UserID
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






