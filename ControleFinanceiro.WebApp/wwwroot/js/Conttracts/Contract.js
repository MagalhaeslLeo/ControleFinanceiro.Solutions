$(document).ready(function () {
	var notas = [];
	const XHRUpload = Uppy.XHRUpload;
	const StatusBar = Uppy.StatusBar;
	const FileInput = Uppy.FileInput;

	//variáveis para o plugin uppy
	var elemId = 'contrato';
	var id = '#' + elemId;
	var $statusBar = $(id + ' .uppy-status');
	var $uploadedList = $(id + ' .uppy-list');
	var timeout;


	$('.readjust').hide();
	$('.numberdate').hide();

	$("#telefone").inputmask("mask", {
		"mask": "(99) 999-999999"
	});

	$("#email").inputmask({
		mask: "*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}]@*{1,20}[.*{2,6}][.*{1,2}]",
		greedy: false,
		onBeforePaste: function (pastedValue, opts) {
			pastedValue = pastedValue.toLowerCase();
			return pastedValue.replace("mailto:", "");
		},
		definitions: {
			'*': {
				validator: "[0-9A-Za-z!#$%&'*+/=?^_`{|}~\-]",
				cardinality: 1,
				casing: "lower"
			}
		}
	});

	var BuildSelect2 = function () {

		$('#clientId').select2({
			placeholder: " Selecione o Cliente com o cnpj* "
		});

		$('#contractTypeId').select2({
			placeholder: "Selecione tipo de Contrato*"
		});

		$('#contractIndexReadjustmentId').select2({
			placeholder: "Selecione o Reajustes*"
		});
	}

	$.ajax({
		method: 'get',
		url: '/Api/ApiContract/GetAllCLients',

	}).done(function (response) {
		response.forEach(function (item) {
			$('#clientId').append('<option value="' + item.id + '"> ' + item.cnpj + ' - ' + item.razaoSocial + '</option>')
		});
	});

	$.ajax({
		method: 'get',
		url: '/Api/ApiContract/GetAllTypes',

	}).done(function (response) {
		response.forEach(function (item) {
			$('#contractTypeId').append('<option value="' + item.id + '"> ' + item.description + ' </option>')
		});
	});

	$.ajax({
		method: 'Get',
		url: '/Api/ApiContract/GetAllReadjustment'
	}).done(function (response) {
		response.forEach(function (item) {
			''
			$('#contractIndexReadjustmentId').append('<option value= "' + item.id + '">' + item.description + '</option>')
		});
	});

	$('.btnRepeater').on('click', function () {
		$('.sltReajuste').append('<label> Descrição </label>')
	});

	$('#btnSalvar').on('click', function () {

		var post = {};
		post = {
			id: $('[name="Id"]').val() || null,
			clientId: $('[name="clientId"]').val() || null,
			contractTypeId: $('[name="contractTypeId"]').val() || null,
			validityInitial: $('[name="validityInitial"]').val() || null,
			validityFinal: $('[name="validityFinal"]').val() || null,
			contractIndexReadjustmentId: $('[name="contractIndexReadjustmentId"]').val() || null,
			contractNumber: $('[name="contractNumber"]').val() || null,
			paymentConditions: $('[name="paymentConditions"]').val() || null,
			nome: $('[name="nome"]').val() || null,
			telefone: $('[name="telefone"]').val() || null,
			email: $('[name="email"]').val() || null,
			numberContrato: $('[name="numberContrato"]').val() || null,
			numberdate: $('[name="numberdate"]').val() || null,
			costs: [],
			files: []
		}

		$('.form-control').removeClass('is-invalid');
		$('.msg-error').remove();
		$('.form-control').not('.is-invalid').addClass('is-valid');
		$('.add').show();

		$('[data-repeater-item]').each((indice, row) => {
			const description = $(`[name="[${indice}][description]"]`, row).val();
			const value = $(`[name="[${indice}][value]"]`, row).inputmask('unmaskedvalue');
			const costId = $(`[name="[${indice}][costId]"]`, row).val() || null;

			var mensage = "Este campo É obrigatório"
			if ((description === null || description === "") && (value === null || value === "")) {

				$('.desc').addClass('validation');
				$('.vlr').addClass('validation');
				$('.validation').addClass('is-invalid');
				$('.desc').removeClass('validation')
				$('.vlr').removeClass('validation');
				$('.add').hide();
				$('.vlr').append('<div class="msg-error">' + mensage + '</div>')
				Swal.fire({
					title: "Campos Obrigatórios!",
					text: "Verifique se há algum campo sem Preenchimento",
					icon: "error",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				})

				return;
			}

			if (description === null || description === "") {

				$('.desc').addClass('validation');
				$('.validation').addClass('is-invalid');
				$('.add').hide();

				if ((value === null || value === "0,00") || (value === "")) {

					$('.vlr').addClass('validation');
					$('.validation').addClass('is-invalid');
					$('.add').hide();
				}

				$('.desc').removeClass('validation')
				$('.vlr').removeClass('validation');
				Swal.fire({
					title: "Campos Obrigatórios!",
					text: "Verifique se há algum campo sem Preenchimento",
					icon: "error",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				})

				return;
			}

			if ((value === null || value === "0,00") || (value === "")) {

				$('.vlr').addClass('validation');
				$('.validation').addClass('is-invalid');
				$('.vlr').removeClass('validation');
				$('.add').hide();
				Swal.fire({
					title: "Campos Obrigatórios!",
					text: "Verifique se há algum campo sem Preenchimento",
					icon: "error",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				})
				return;
			}

			post.costs.push({ description, value, costId });
		});
		post.files = notas;

		var json = JSON.stringify(post);

		$.ajax({
			method: 'POST',
			url: '/api/ApiContract/SaveContract',
			data: json,
			data: json,
			contentType: 'application/json/',
		}).done(function (response) {
			if (response === true) {
				Swal.fire({
					title: "Negado !",
					text: "Cliente já Cadastrado",
					icon: "error",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				}).then(function () {
					window.location.href = "/Contract/ContractList";
				});
			} else {
				Swal.fire({
					title: "Concluido!",
					text: "Com Sucessso",
					icon: "success",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				}).then(function () {
					window.location.href = "/Contract/ContractList";
				});
			}
			if (response === false) {
				Swal.fire({
					title: "Negado !",
					text: "A data final não pode ser menor que a data inicial",
					icon: "error",
					buttonsStyling: false,
					confirmButtonText: "Ok!",
					customClass: {
						confirmButton: "btn btn-success"
					}
				}).then(function () {
					window.location.href = "/Contract/RegisterContract";
				});
			}
		}).fail(function (response) {

			var errors = response.responseJSON.errors;
			Object.keys(errors).forEach(item => {

				var it = item.replace('$.', '');

				$(`[name*='${it}' i]`).addClass('is-invalid');

				errors[item].forEach(mensage => {
					$(`div[id*='erros-${it}' i]`).append('<div class="msg-error">' + mensage + '</div>')
				});
			});
		});

	})

	var repeater = $('#kt_repeater_3').repeater({

		initEmpty: false,

		show: function () {
			$(this).slideDown();
		},

		hide: function (deleteElement) {

			var id_custo = $(this).find(':hidden').val();

			Swal.fire({
				title: "Excluir ?",
				text: "Não Será possível reverte esta exclusão !",
				icon: "warning",
				showCancelButton: true,
				confirmButtonText: "Ok",
				cancelButtonText: " Cancelar",
				reverseButtons: true
			}).then(function (result) {

				if (result.value) {

					$.ajax({
						method: 'POST',
						url: '/Api/ApiContract/MarkCOstAsDeleted/' + id_custo,
						contentType: '/application/json'
					}).done(function (response) {

						$(this).slideUp(deleteElement)

						/*window.location.href = "/Contract/ContractList";*/

					});
				}
			});
		}
	});

	if ($('#Id').val() !== '') {
		$.ajax({
			method: 'Get',
			url: '/Api/ApiContract/GetByIdContract?Id=' + $('#Id').val(),
		}).done(function (response) {
			Object.keys(response).forEach((item) => {
				$('#' + item).val(response[item]);
			});

			repeater.setList(

				response.costs
			);

			response.files.forEach(GerarListaDeNotasFiscais);


			if ($('#action').val() == 'Consult') {
				$('.readOnly').attr('readonly', 'readonly');
				$('.readOnly').prop('disabled', true);
				$('.btnHide').hide();
				$('.add').hide();
				$('.delete').hide();
				$('a.voltar').text('Voltar');
				$('.numberdate').show();
			}

			if ($('#action').val() == 'Edit') {
				$('.numberdate').prop('disabled', true);
				$('.btnHide').show();
				$('.numberdate').show();
			}

			$('select').trigger('change');
		});
	}


	function GerarListaDeNotasFiscais(nota) {
		var uploadListHtml = '<div class="uppy-list-item" data-sharepoint="' + nota.id + '">\
								<div class="uppy-list-label">' + nota.fileName + '</div>\
								<span class="uppy-list-remove" data-sharepoint="' + nota.id + '"><i class="flaticon2-cancel-music"></i></span>\
							 </div>';
		$uploadedList.append(uploadListHtml);
	}

	function InitUppyPlugin() {
		var uppyMin = Uppy.Core({
			debug: true,
			autoProceed: true,
			showProgressDetails: true,
			restrictions: {
				maxFileSize: 1000000, // 1mb
				maxNumberOfFiles: 5,
				minNumberOfFiles: 1
			}
		});

		uppyMin.use(FileInput, { target: id + ' .uppy-wrapper', pretty: false });
		uppyMin.use(XHRUpload, { endpoint: '/api/ApiFileContract/upload' });
		uppyMin.use(StatusBar, {
			target: id + ' .uppy-status',
			hideUploadButton: true,
			hideAfterFinish: false
		});

		$(id + ' .uppy-FileInput-input').addClass('uppy-input-control').attr('id', elemId + '_input_control');
		$(id + ' .uppy-FileInput-input').attr('name', 'files');
		$(id + ' .uppy-FileInput-container').append('<label class="uppy-input-label btn btn-light-primary btn-sm btn-bold" for="' + (elemId + '_input_control') + '">Adicionar Contrato</label>');

		var $fileLabel = $(id + ' .uppy-input-label');

		uppyMin.on('upload', function (data) {
			$fileLabel.text("Uploading...");
			$statusBar.addClass('uppy-status-ongoing');
			$statusBar.removeClass('uppy-status-hidden');
			clearTimeout(timeout);
		});

		uppyMin.on('complete', function (file) {
			$.each(file.successful, function (index, value) {
				GerarListaDeNotasFiscais(value.response.body);
				notas.push(value.response.body);
			});

			$fileLabel.text("Adicionar Contrato");
			$statusBar.addClass('uppy-status-hidden');
			$statusBar.removeClass('uppy-status-ongoing');
		});

		$(document).on('click', id + ' .uppy-list .uppy-list-remove', function () {
			var item = $(this);
			var sharepointId = item.data('sharepoint');

			if (sharepointId) {
				$.ajax({
					method: 'POST',
					url: '/api/ApiFileContract/RemoveFile/' + sharepointId
				}).done(function (response) {
					if (response.success) {
						$(id + ' .uppy-list-item[data-sharepoint="' + sharepointId + '"').remove();
					} else {
						//adicionar modal com mensagem que não possível realizar a delação do arquivo
					}
				});
			}
		});
	}
	BuildSelect2();

	$(":input").inputmask();

	InitUppyPlugin();

});

