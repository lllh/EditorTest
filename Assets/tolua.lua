--------------------------------------------------------------------------------
--      Copyright (c) 2015 - 2016 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--      Use, modification and distribution are subject to the "MIT License"
--------------------------------------------------------------------------------
if jit then		
	if jit.opt then		
		jit.opt.start(3)				
	end		
	
	print("ver"..jit.version_num.." jit: ", jit.status())
	print(string.format("os: %s, arch: %s", jit.os, jit.arch))
end

if DebugServerIp then  
  require("mobdebug").start(DebugServerIp)
end

require "lib.misc.functions"
Mathf		= require "lib.UnityEngine.Mathf"
Vector3 	= require "lib.UnityEngine.Vector3"
Quaternion	= require "lib.UnityEngine.Quaternion"
Vector2		= require "lib.UnityEngine.Vector2"
Vector4		= require "lib.UnityEngine.Vector4"
Color		= require "lib.UnityEngine.Color"
Ray			= require "lib.UnityEngine.Ray"
Bounds		= require "lib.UnityEngine.Bounds"
RaycastHit	= require "lib.UnityEngine.RaycastHit"
Touch		= require "lib.UnityEngine.Touch"
LayerMask	= require "lib.UnityEngine.LayerMask"
Plane		= require "lib.UnityEngine.Plane"
Time		= reimport "lib.UnityEngine.Time"

list		= require "lib.list"
utf8		= require "lib.misc.utf8"

require "lib.event"
require "lib.typeof"
require "lib.slot"
require "lib.System.Timer"
require "lib.System.coroutine"
require "lib.System.ValueType"
require "lib.System.Reflection.BindingFlags"

json = require "cjson.safe"
bit = require "bit"


reimport("Common.init")
int64.zero = int64.new(0,0)
uint64.zero = uint64.new(0,0)
LuaEvent = reimport("lib.Events.LuaEvent")
MyEvent = reimport("lib.Events.MyEvent")
Base = reimport("Packages.init")
reimport("AppInfo.AppInfo")
reimport("UnityEngineEvents")

AppModel = reimport("Common.AppModel"):create()
UserModel = reimport("Common.UserModel"):create()

__G__TRACKBACK__ = function(msg)
    local msg = debug.traceback(msg, 3)
    print(msg)
    tolua.error(msg)
    return msg
end

local __g = _G
LuaFramework.exports = {}

setmetatable(LuaFramework.exports, {
    __newindex = function(_, name, value)
        rawset(__g, name, value)
    end,

    __index = function(_, name)
        return rawget(__g, name)
    end
})

-- disable create unexpected global variable
function LuaFramework.disable_global(bool)
    if bool then
        setmetatable(__g, {
            __newindex = function(_, name, value)
                error(string.format("USE \" LuaFramework.exports.%s = value \" INSTEAD OF SET GLOBAL VARIABLE", name), 0)
            end
        })
    else
       setmetatable(__g, {
            __newindex = function(_, name, value)
                rawset(__g, name, value)
            end
        }) 
    end
end


LuaFramework.disable_global(true)

print("init tolua complete.")
--require "misc.strict"