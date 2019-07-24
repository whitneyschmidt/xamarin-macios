using CoreFoundation;
using ObjCRuntime;
using Foundation;
using System;

namespace HealthKit
{
	// NSInteger -> HKDefines.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKUpdateFrequency : long {
		Immediate = 1,
		Hourly,
		Daily,
		Weekly
	}

	// NSInteger -> HKDefines.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKAuthorizationStatus : long {
		NotDetermined = 0,
		SharingDenied,
		SharingAuthorized
	}

	// NSInteger -> HKDefines.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKBiologicalSex : long {
		NotSet = 0,
		Female,
		Male,
		[iOS (8,2)]
		Other
	}

	// NSInteger -> HKDefines.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKBloodType : long {
		NotSet = 0,
		APositive,
		ANegative,
		BPositive,
		BNegative,
		ABPositive,
		ABNegative,
		OPositive,
		ONegative
	}

	// NSInteger -> HKMetadata.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKBodyTemperatureSensorLocation : long {
		Other = 0,
		Armpit,
		Body,
		Ear,
		Finger,
		GastroIntestinal,
		Mouth,
		Rectum,
		Toe,
		EarDrum,
		TemporalArtery,
		Forehead
	}

	// NSInteger -> HKMetadata.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKHeartRateSensorLocation : long {
		Other = 0,
		Chest,
		Wrist,
		Finger,
		Hand,
		EarLobe,
		Foot
	}

	// NSInteger -> HKObjectType.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKQuantityAggregationStyle : long {
		Cumulative = 0,
		[iOS (13, 0), Watch (6, 0)]
		DiscreteArithmetic,
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'HKQuantityAggregationStyle.DiscreteArithmetic'.")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'HKQuantityAggregationStyle.DiscreteArithmetic'.")]
		Discrete = DiscreteArithmetic,
		[iOS (13, 0), Watch (6, 0)]
		DiscreteTemporallyWeighted,
		[iOS (13, 0), Watch (6, 0)]
		DiscreteEquivalentContinuousLevel,
	}

	// NSInteger -> HKObjectType.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKCategoryValueSleepAnalysis : long {
		InBed,
		Asleep,
		[Watch (3,0), iOS (10,0)]
		Awake,
	}

	// NSUInteger -> HKQuery.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	[Flags]
	public enum HKQueryOptions : ulong {
		None               = 0,
		StrictStartDate    = 1 << 0,
		StrictEndDate      = 1 << 1
	}

	// NSUInteger -> HKStatistics.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	[Flags]
	public enum HKStatisticsOptions : ulong {
		None              	  = 0,
		SeparateBySource          = 1 << 0,
		DiscreteAverage           = 1 << 1,
		DiscreteMin               = 1 << 2,
		DiscreteMax               = 1 << 3,
		CumulativeSum             = 1 << 4,
		[iOS (13, 0), Watch (6, 0)]
		MostRecent                = 1 << 5,
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'HKStatisticsOptions.MostRecent'.")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'HKStatisticsOptions.MostRecent'.")]
		DiscreteMostRecent        = MostRecent,
		[iOS (13, 0), Watch (6, 0)]
		Duration                  = 1 << 6,
	}

	// NSInteger -> HKUnit.h
	[Watch (2,0)]
	[iOS (8,0)]
	[Native]
	public enum HKMetricPrefix : long {
		None = 0,
		Pico,
		Nano,
		Micro,
		Milli,
		Centi,
		Deci,
		Deca,
		Hecto,
		Kilo,
		Mega,
		Giga,
		Tera,
		[iOS (13, 0), Watch (6, 0)]
		Femto,
	}

	[Native]
	[Watch (2,0)]
	[iOS (8,0)]
	public enum HKWorkoutActivityType : ulong {
		AmericanFootball = 1,
		Archery,
		AustralianFootball,
		Badminton,
		Baseball,
		Basketball,
		Bowling,
		Boxing,
		Climbing,
		Cricket,
		CrossTraining,
		Curling,
		Cycling,
		Dance,
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		DanceInspiredTraining,
		Elliptical,
		EquestrianSports,
		Fencing,
		Fishing,
		FunctionalStrengthTraining,
		Golf,
		Gymnastics,
		Handball,
		Hiking,
		Hockey,
		Hunting,
		Lacrosse,
		MartialArts,
		MindAndBody,
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'MixedCardio' or 'HighIntensityIntervalTraining' instead.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'MixedCardio' or 'HighIntensityIntervalTraining' instead.")]
		MixedMetabolicCardioTraining,
		PaddleSports,
		Play,
		PreparationAndRecovery,
		Racquetball,
		Rowing,
		Rugby,
		Running,
		Sailing,
		SkatingSports,
		SnowSports,
		Soccer,
		Softball,
		Squash,
		StairClimbing,
		SurfingSports,
		Swimming,
		TableTennis,
		Tennis,
		TrackAndField,
		TraditionalStrengthTraining,
		Volleyball,
		Walking,
		WaterFitness,
		WaterPolo,
		WaterSports,
		Wrestling,
		Yoga,
		[iOS (10,0), Watch (3,0)]
		Barre,
		[iOS (10,0), Watch (3,0)]
		CoreTraining,
		[iOS (10,0), Watch (3,0)]
		CrossCountrySkiing,
		[iOS (10,0), Watch (3,0)]
		DownhillSkiing,
		[iOS (10,0), Watch (3,0)]
		Flexibility,
		[iOS (10,0), Watch (3,0)]
		HighIntensityIntervalTraining,
		[iOS (10,0), Watch (3,0)]
		JumpRope,
		[iOS (10,0), Watch (3,0)]
		Kickboxing,
		[iOS (10,0), Watch (3,0)]
		Pilates,
		[iOS (10,0), Watch (3,0)]
		Snowboarding,
		[iOS (10,0), Watch (3,0)]
		Stairs,
		[iOS (10,0), Watch (3,0)]
		StepTraining,
		[iOS (10,0), Watch (3,0)]
		WheelchairWalkPace,
		[iOS (10,0), Watch (3,0)]
		WheelchairRunPace,
		[iOS (11,0), Watch (4,0)]
		TaiChi,
		[iOS (11, 0), Watch (4, 0)]
		MixedCardio,
		[iOS (11, 0), Watch (4, 0)]
		HandCycling,
		[iOS (13, 0), Watch (6, 0)]
		DiscSports,
		[iOS (13, 0), Watch (6, 0)]
		FitnessGaming,
		[iOS (8,2)]
		Other = 3000
	}

	[Native]
	[Watch (2,0)]
	[iOS (8,0)]
	public enum HKWorkoutEventType : long {
		Pause = 1,
		Resume,
		[iOS (10,0), Watch (3,0)]
		Lap,
		[iOS (10,0), Watch (3,0)]
		Marker,
		[iOS (10,0), Watch (3,0)]
		MotionPaused,
		[iOS (10,0), Watch (3,0)]
		MotionResumed,
		[iOS (11, 0), Watch (4, 0)]
		Segment,
		[iOS (11, 0), Watch (4, 0)]
		PauseOrResumeRequest,
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKCategoryValue : long {
		NotApplicable = 0
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKCategoryValueCervicalMucusQuality : long {
		NotApplicable = 0,
		Dry = 1,
		Sticky,
		Creamy,
		Watery,
		EggWhite
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKCategoryValueMenstrualFlow : long {
		NotApplicable = 0,
		Unspecified = 1,
		Light,
		Medium,
		Heavy
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKCategoryValueOvulationTestResult : long {
		NotApplicable = 0,
		Negative = 1,
		[iOS (13, 0), Watch (6, 0)]
		LuteinizingHormoneSurge = 2,
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'HKCategoryValueOvulationTestResult.LuteinizingHormoneSurge' instead.")]
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'HKCategoryValueOvulationTestResult.LuteinizingHormoneSurge' instead.")]
		Positive = LuteinizingHormoneSurge,
		Indeterminate = 3,
		[iOS (13, 0), Watch (6, 0)]
		EstrogenSurge = 4,
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKCategoryValueAppleStandHour : long {
		Stood = 0,
		Idle
	}

	[iOS (13,0)]
	[Watch (6,0)]
	[Native]
	public enum HKCategoryValueAudioExposureEvent : long {
		AudioExposureEventLoudEnvironment = 1,
	}

	[Watch (2,0)]
	[iOS (9,0)]
	[Native]
	public enum HKFitzpatrickSkinType : long {
		NotSet = 0,
		I,
		II,
		III,
		IV,
		V,
		VI
	}

	[Watch (3,0), iOS (10,0)]
	[Native]
	public enum HKWheelchairUse : long {
		NotSet = 0,
		No,
		Yes,
	}

	[Watch (3,0), iOS (10,0)]
	[Native]
	public enum HKWeatherCondition : long {
		None = 0,
		Clear,
		Fair,
		PartlyCloudy,
		MostlyCloudy,
		Cloudy,
		Foggy,
		Haze,
		Windy,
		Blustery,
		Smoky,
		Dust,
		Snow,
		Hail,
		Sleet,
		FreezingDrizzle,
		FreezingRain,
		MixedRainAndHail,
		MixedRainAndSnow,
		MixedRainAndSleet,
		MixedSnowAndSleet,
		Drizzle,
		ScatteredShowers,
		Showers,
		Thunderstorms,
		TropicalStorm,
		Hurricane,
		Tornado,
	}

	[Watch (3,0), iOS (10,0)]
	[Native]
	public enum HKWorkoutSwimmingLocationType : long {
		Unknown = 0,
		Pool,
		OpenWater,
	}

	[Watch (3,0), iOS (10,0)]
	[Native]
	public enum HKSwimmingStrokeStyle : long {
		Unknown = 0,
		Mixed,
		Freestyle,
		Backstroke,
		Breaststroke,
		Butterfly,
	}

	[Watch (4, 0), iOS (11, 0)]
	[Native]
	public enum HKInsulinDeliveryReason : long {
		Basal = 1,
		Bolus,
#if !XAMCORE_4_0
		[Obsolete ("Use 'Basal' instead.")]
		Asal = Basal,
		[Obsolete ("Use 'Bolus' instead.")]
		Olus = Bolus,
#endif
	}

	[Watch (4, 0), iOS (11, 0)]
	[Native]
	public enum HKBloodGlucoseMealTime : long {
		Preprandial = 1,
		Postprandial,
#if !XAMCORE_4_0
		[Obsolete ("Use 'Preprandial' instead.")]
		Reprandial = Preprandial,
		[Obsolete ("Use 'Postprandial' instead.")]
		Ostprandial = Postprandial,
#endif
	}

	[Watch (4, 0), iOS (11, 0)]
	[Native]
	public enum HKVO2MaxTestType : long {
		MaxExercise = 1,
		PredictionSubMaxExercise,
		PredictionNonExercise,
	}
 
	[NoWatch, iOS (12, 0)]
	public enum HKFhirResourceType {
		[Field ("HKFHIRResourceTypeAllergyIntolerance")]
		AllergyIntolerance,
		[Field ("HKFHIRResourceTypeCondition")]
		Condition,
		[Field ("HKFHIRResourceTypeImmunization")]
		Immunization,
		[Field ("HKFHIRResourceTypeMedicationDispense")]
		MedicationDispense,
		[Field ("HKFHIRResourceTypeMedicationOrder")]
		MedicationOrder,
		[Field ("HKFHIRResourceTypeMedicationStatement")]
		MedicationStatement,
		[Field ("HKFHIRResourceTypeObservation")]
		Observation,
		[Field ("HKFHIRResourceTypeProcedure")]
		Procedure,
	}

	[Watch (5, 0), iOS (12, 0)]
	public enum HKClinicalTypeIdentifier {

		[Field ("HKClinicalTypeIdentifierAllergyRecord")]
		AllergyRecord,
		[Field ("HKClinicalTypeIdentifierConditionRecord")]
		ConditionRecord,
		[Field ("HKClinicalTypeIdentifierImmunizationRecord")]
		ImmunizationRecord,
		[Field ("HKClinicalTypeIdentifierLabResultRecord")]
		LabResultRecord,
		[Field ("HKClinicalTypeIdentifierMedicationRecord")]
		MedicationRecord,
		[Field ("HKClinicalTypeIdentifierProcedureRecord")]
		ProcedureRecord,
		[Field ("HKClinicalTypeIdentifierVitalSignRecord")]
		VitalSignRecord,
	}

	[Watch (5,0), iOS (12,0)]
	[Native]
	public enum HKAuthorizationRequestStatus : long 
	{
		Unknown = 0,
		ShouldRequest,
		Unnecessary,
	}
}
