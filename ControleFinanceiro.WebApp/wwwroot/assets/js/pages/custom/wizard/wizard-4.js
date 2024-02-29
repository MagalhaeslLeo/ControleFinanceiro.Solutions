"use strict";

// Class definition
var KTWizard4 = function () {
	// Base elements
	var _wizardEl;
	var _formEl;
	var _wizard;

	// Private functions
	var initWizard = function () {
		// Initialize form wizard
		_wizard = new KTWizard(_wizardEl, {
			startStep: 1, // initial active step number
			clickableSteps: true  // allow step clicking
		});

		// Change event
		_wizard.on('change', function (wizard) {
			KTUtil.scrollTop();
		});
	}

	return {
		// public functions
		init: function () {
			_wizardEl = KTUtil.getById('formWizard');
			_formEl = KTUtil.getById('kt_form');

			initWizard();
		}
	};
}();

jQuery(document).ready(function () {
	KTWizard4.init();
});
