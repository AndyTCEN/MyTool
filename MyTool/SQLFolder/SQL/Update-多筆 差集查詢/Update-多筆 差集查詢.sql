select * from [dbo].[COUPONS_GIVE] A
Join [dbo].[MBR_PROFILE]  B on B.varMBR_ID=A.varMbrID


--Select®t¶°
select * from [dbo].[COUPONS_GIVE] A
Join
(
select varMbrID from [dbo].[COUPONS_GIVE]
Except
select varMBR_ID from [dbo].[MBR_PROFILE]
)B on A.varMbrID=B.varMbrID


--Update¦hµ§¡A®t¶°
update [dbo].[COUPONS_GIVE]  Set intDisNumber='200' 
where varMbrID in (
select varMbrID from [dbo].[COUPONS_GIVE]
Except
select varMBR_ID from [dbo].[MBR_PROFILE]
)

