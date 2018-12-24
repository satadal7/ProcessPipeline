#
# Variables
#

ifeq ($(CONFIGURATION),)
CONFIGURATION = Release
endif

LIBNAME = AsmichiProcessPipeline
HELPERNAME = Asmichi.ProcessPipeline.Helper
SRCDIR = ./
OBJDIR = ../../obj/ProcessPipeline.Native/$(CONFIGURATION)/

SRCS_LIB = $(addprefix $(SRCDIR),lib.c)
OBJS_LIB = $(addprefix $(OBJDIR),$(SRCS_LIB:.c=.o))
SRCS_HELPER = $(addprefix $(SRCDIR),helper.c)
OBJS_HELPER = $(addprefix $(OBJDIR),$(SRCS_HELPER:.c=.o))
CC = gcc

CFLAGS = -g -gdwarf -MMD -std=c11 -fPIC -Wextra -Wswitch -Wswitch -Werror
LDFLAGS_COMMON = -Wl,--no-undefined -Wl,-z,relro -Wl,-z,now -Wl,-z,noexecstack
LDFLAGS = $(LDFLAGS_COMMON)
LDFLAGS_SHARED = $(LDFLAGS_COMMON) -shared -Wl,-soname,lib$(LIBNAME).so -Wl,--version-script=$(SRCDIR)$(LIBNAME).version

ifeq ($(CONFIGURATION),Release)
CFLAGS += -O3
else ifeq ($(CONFIGURATION),Debug)
CFLAGS += -O0 -fno-omit-frame-pointer
else
$(error Unknown CONFIGURATION: $(CONFIGURATION))
endif

#
# Targets
#
.PHONY : all
all: $(OBJDIR)lib$(LIBNAME).so $(OBJDIR)$(HELPERNAME)

-include $(OBJS:.o=.d)

$(OBJDIR)%.o : $(SRCDIR)%.c
	mkdir -p $(dir $@)
	$(CC) $(CFLAGS) -o $@ -c $<

$(OBJDIR)lib$(LIBNAME).so: $(OBJS_LIB) $(SRCDIR)$(LIBNAME).version
	mkdir -p $(dir $@)
	$(CC) $(LDFLAGS_SHARED) -o $@ $(OBJS_LIB)

$(OBJDIR)$(HELPERNAME) : $(OBJS_HELPER)
	mkdir -p $(dir $@)
	$(CC) $(LDFLAGS) -o $@ $(OBJS_HELPER)
