
$(function(){


    var speed = 400;

	$('#to-recover').click(function(){
		
		$("#loginform").slideUp();
		$("#recoverform").fadeIn();
	});
	$('#to-login').click(function(){
		
		$("#recoverform").hide();
		$("#loginform").fadeIn();
	});
	
	
	$('#to-login').click(function(){
	
	});
    /*
    if($.browser.msie == true && $.browser.version.slice(0,3) < 10) {
        $('input[placeholder]').each(function(){ 
       
        var input = $(this);       
       
        $(input).val(input.attr('placeholder'));
               
        $(input).focus(function(){
             if (input.val() == input.attr('placeholder')) {
                 input.val('');
             }
        });
       
        $(input).blur(function(){
            if (input.val() == '' || input.val() == input.attr('placeholder')) {
                input.val(input.attr('placeholder'));
            }
        });
    });

        
        
    }
    */
    
	$('#loginform').bootstrapValidator({
	    message: 'This value is not valid',
	    feedbackIcons: {
	        valid: 'glyphicon glyphicon-ok',
	        invalid: 'glyphicon glyphicon-remove',
	        validating: 'glyphicon glyphicon-refresh'
	    },
	    fields: {
	        account: {
	            validators: {
	                notEmpty: {},
	                stringLength: {
	                    min: 4,
	                    max: 20
	                },
	                regexp: {
	                    regexp: /^[a-zA-Z0-9_\.]+$/
	                }
	            }
	        },
	        password: {
	            validators: {
	                notEmpty: {},
	                stringLength: {
	                    min: 6,
	                    max: 20
	                }
	            }
	        }
	    }
	}).on('success.form.bv', function (e) {
	    // Prevent form submission
	    e.preventDefault();

	    // Get the form instance
	    var $form = $(e.target);

	    // Get the BootstrapValidator instance
	    var bv = $form.data('bootstrapValidator');

	    // Use Ajax to submit form data
	    $.post($form.attr('action'), $form.serialize(), function (result) {
	        console.log(result);
	        if (!result.IsError) {
	            location = result.Msg;
	        } else {
	            Modal.alert({
	                msg: result.Msg
	            }).on(function (e) {
	                $("#account").focus();
	            });
	        }
	    }, 'json');
	});
	$("#loginbtn").click(function () {
	    $('#loginform').submit();
	});

});