set RemotePath=%1
set LocalPath=%SystemDrive%\SSGSEMS

if not exist %RemotePath% (
echo build path %RemotePath% does not exist
goto Error
)

if exist %LocalPath% (
 rmdir /s /q %LocalPath%
)

mkdir %LocalPath%
copy /y %RemotePath%\* %LocalPath%\.
xcopy /cseirdzv %RemotePath% %LocalPath%