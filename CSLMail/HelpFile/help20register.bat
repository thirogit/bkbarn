@echo off

IF "%1" == "" goto _install

:_uninstall
@echo on
H2Reg.exe /u "cmdfile=h2reg_cmd.ini"
@echo off
GOTO _end

:_install
@echo on
H2Reg.exe /r "cmdfile=h2reg_cmd.ini"
@echo off
GOTO _end

:_H2RegMessage
@echo on
echo H2Reg.exe from Far Technologies is required to register the Help Collection
goto _end

:_end