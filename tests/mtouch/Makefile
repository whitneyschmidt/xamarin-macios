TOP=../..

include $(TOP)/Make.config

export MD_MTOUCH_SDK_ROOT=$(IOS_DESTDIR)/$(MONOTOUCH_PREFIX)
export TargetFrameworkFallbackSearchPaths=$(IOS_DESTDIR)/Library/Frameworks/Mono.framework/External/xbuild-frameworks
export MSBuildExtensionsPathFallbackPathsOverride=$(IOS_DESTDIR)/Library/Frameworks/Mono.framework/External/xbuild

check: run-tests

NUNIT_MSBUILD_DIR=$(TOP)/packages/NUnit.ConsoleRunner.3.9.0/tools/

all-local::
	$(MAKE) dependencies
	$(MAKE) run-tests

# example command to run a single test:
#     make run-tests TEST_FIXTURE=-test=Xamarin.MTouch.MT1016
# or multiple tests:
#     make run-tests TEST_FIXTURE="-test=Xamarin.MTouch.MT1016,Xamarin.MTouch.MT1017"

run-tests: bin/Debug/mtouch.dll test.config
	rm -f .failed-stamp
	$(SYSTEM_MONO) --debug $(TOP)/packages/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe "$(abspath $<)" "--result=$(abspath $(CURDIR)/TestResult.xml);format=nunit2" $(TEST_FIXTURE) --labels=All --inprocess || touch $(CURDIR)/.failed-stamp
	@# Create an html file and tell MonkeyWrench to upload it (if we're running there)
	@[[ -z "$$BUILD_REPOSITORY" ]] || \
		( xsltproc $(TOP)/tests/HtmlTransform.xslt TestResult.xml  > index.html && \
		echo "@MonkeyWrench: AddFile: $$PWD/index.html")
	@[[ ! -e .failed-stamp ]] 

# mtouch.csproj.inc contains the mtouch_dependencies variable used to determine if mtouch.dll needs to be rebuilt or not.
mtouch.csproj.inc: $(TOP)/tools/common/create-makefile-fragment.sh Makefile $(TOP)/Make.config
	$(Q_GEN) $< $(CURDIR)/mtouch.csproj
-include mtouch.csproj.inc

bin/Debug/mtouch.dll: $(mtouch_dependencies)
	$(Q_XBUILD) $(SYSTEM_XIBUILD) -t -- /Library/Frameworks//Mono.framework/Versions/Current/lib/mono/nuget/NuGet.exe restore packages.config
	$(SYSTEM_XIBUILD) -- mtouch.csproj $(XBUILD_VERBOSITY)
	$(Q) rm -f .failed-stamp

build: bin/Debug/mtouch.dll

test.config: $(TOP)/Make.config Makefile
	@rm -f $@
	@echo "MONOTOUCH_PREFIX=$(MONOTOUCH_PREFIX)" >> $@
	@echo "SDK_VERSION=$(IOS_SDK_VERSION)" >> $@
	@echo "XCODE_DEVELOPER_ROOT=$(XCODE_DEVELOPER_ROOT)" >> $@
	@echo "DESTDIR=$(IOS_DESTDIR)" >> $@
	@echo "IOS_DESTDIR=$(IOS_DESTDIR)" >> $@

dependencies:
	cd .. && $(MAKE)
	$(MAKE) -C $(TOP)/tests/test-libraries
	$(MAKE) build
